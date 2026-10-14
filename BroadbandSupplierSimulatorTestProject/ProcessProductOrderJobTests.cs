using System.Net;
using System.Text.Json;
using BroadbandSupplierSimulator.Data.Entities;
using BroadbandSupplierSimulator.Jobs;
using BroadbandSupplierSimulator.Simulation;
using Hangfire.States;
using Microsoft.Extensions.Logging.Abstractions;

namespace BroadbandSupplierSimulatorTestProject;

public class ProcessProductOrderJobTests
{
    private const string Url = "http://localhost/notify";

    private static ProductOrderItem Item(string id, ProductOrderItemState? state = null, string? subStatus = null) =>
        new() { Id = Guid.NewGuid(), ItemId = id, State = state, SubStatus = subStatus };

    private static ProductOrder Order(params ProductOrderItem[] items) =>
        new() { Id = Guid.NewGuid(), Items = [.. items] };

    private class Harness
    {
        public required ProductOrder Order { get; init; }
        public required FakeRepository Repository { get; init; }
        public required FakeBackgroundJobClient Jobs { get; init; }
        public required RecordingHandler Http { get; init; }
        public required ProcessProductOrderJob Job { get; init; }

        public Task RunAsync() => Job.ProcessAsync(Order.Id, CancellationToken.None);
    }

    private static Harness Create(ProductOrder order, SimulationOptions? options = null, HttpStatusCode status = HttpStatusCode.Created, bool orderExists = true)
    {
        options ??= new SimulationOptions { SendUrl = Url };
        var repository = new FakeRepository(orderExists ? order : null);
        var jobs = new FakeBackgroundJobClient();
        var http = new RecordingHandler(status);
        var job = new ProcessProductOrderJob(NullLogger<ProcessProductOrderJob>.Instance, repository, jobs, new FakeHttpClientFactory(http), new FakeOptionsMonitor(options));
        return new Harness { Order = order, Repository = repository, Jobs = jobs, Http = http, Job = job };
    }

    [Fact]
    public async Task OrderNotFound_DoesNothing()
    {
        var h = Create(Order(Item("1")), orderExists: false);

        await h.RunAsync();

        Assert.Equal(0, h.Repository.UpdateCount);
        Assert.Empty(h.Http.Requests);
        Assert.Empty(h.Jobs.Created);
    }

    [Theory]
    [InlineData(ProductOrderItemState.Completed)]
    [InlineData(ProductOrderItemState.Rejected)]
    [InlineData(ProductOrderItemState.Failed)]
    [InlineData(ProductOrderItemState.Cancelled)]
    public async Task AllItemsTerminal_ReturnsWithoutChangesOrMessages(ProductOrderItemState state)
    {
        var h = Create(Order(Item("1", state), Item("2", state)));

        await h.RunAsync();

        Assert.Equal(0, h.Repository.UpdateCount);
        Assert.Empty(h.Http.Requests);
        Assert.Empty(h.Jobs.Created);
    }

    [Fact]
    public async Task NullState_MovesToAcknowledged_SendsAndReschedules()
    {
        var h = Create(Order(Item("1")));

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.Acknowledged, h.Order.Items[0].State);
        Assert.Equal(1, h.Repository.UpdateCount);
        Assert.Single(h.Http.Requests);
        Assert.Single(h.Jobs.Created);
    }

    [Fact]
    public async Task Acknowledged_MovesToInProgressWithFirstSubStatus()
    {
        var h = Create(Order(Item("1", ProductOrderItemState.Acknowledged)));

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.InProgress, h.Order.Items[0].State);
        Assert.Equal("AcceptedByBTWwBC", h.Order.Items[0].SubStatus);
    }

    [Theory]
    [InlineData("AcceptedByBTWwBC", "AwaitingECCConfirmation")]
    [InlineData("AwaitingECCConfirmation", "CommittedByBTWwBC")]
    [InlineData("CommittedByBTWwBC", "CompletedBTWwBCService")]
    public async Task InProgress_AdvancesSubStatusAndStaysInProgress(string current, string expected)
    {
        var h = Create(Order(Item("1", ProductOrderItemState.InProgress, current)));

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.InProgress, h.Order.Items[0].State);
        Assert.Equal(expected, h.Order.Items[0].SubStatus);
        Assert.Single(h.Jobs.Created);
    }

    [Fact]
    public async Task InProgress_AtFinalSubStatus_CompletesAndDoesNotReschedule()
    {
        var h = Create(Order(Item("1", ProductOrderItemState.InProgress, "CompletedBTWwBCService")));

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.Completed, h.Order.Items[0].State);
        Assert.Single(h.Http.Requests);
        Assert.Empty(h.Jobs.Created);
    }

    [Fact]
    public async Task FullLifecycle_ReachesCompletedInExpectedNumberOfRuns()
    {
        var h = Create(Order(Item("1")));
        var runs = 0;

        while (h.Order.Items[0].State != ProductOrderItemState.Completed && runs < 20)
        {
            await h.RunAsync();
            runs++;
        }

        // null -> Acknowledged -> InProgress (entry + 3 sub status advances) -> Completed
        Assert.Equal(6, runs);
        Assert.Equal(6, h.Http.Requests.Count);
        Assert.Equal(5, h.Jobs.Created.Count);
    }

    [Fact]
    public async Task OnlyNonTerminalItemsAreAdvanced()
    {
        var done = Item("1", ProductOrderItemState.Completed);
        var pending = Item("2", ProductOrderItemState.Acknowledged);
        var h = Create(Order(done, pending));

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.Completed, done.State);
        Assert.Equal(ProductOrderItemState.InProgress, pending.State);
    }

    [Fact]
    public async Task Reschedules_UsingMessageGap()
    {
        var h = Create(Order(Item("1")), new SimulationOptions { SendUrl = Url, MessageGapMs = 1500 });

        await h.RunAsync();

        var state = Assert.IsType<ScheduledState>(Assert.Single(h.Jobs.Created).State);
        Assert.InRange(state.EnqueueAt - DateTime.UtcNow, TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(1600));
        Assert.Equal(nameof(IProcessProductOrderJob.ProcessAsync), h.Jobs.Created[0].Job.Method.Name);
        Assert.Equal(h.Order.Id, h.Jobs.Created[0].Job.Args[0]);
    }

    [Fact]
    public async Task NegativeMessageGap_IsTreatedAsZero()
    {
        var h = Create(Order(Item("1")), new SimulationOptions { SendUrl = Url, MessageGapMs = -5000 });

        await h.RunAsync();

        var state = Assert.IsType<ScheduledState>(Assert.Single(h.Jobs.Created).State);
        Assert.True(state.EnqueueAt <= DateTime.UtcNow.AddSeconds(1));
    }

    [Fact]
    public async Task Sends_PostToSendUrl_WithUpdatedStateInPayload()
    {
        var h = Create(Order(Item("1", ProductOrderItemState.Acknowledged)));

        await h.RunAsync();

        var request = Assert.Single(h.Http.Requests);
        Assert.Equal(Url, request.Url!.ToString());
        using var json = JsonDocument.Parse(request.Body);
        var item = json.RootElement.GetProperty("event").GetProperty("productOrder").GetProperty("productOrderItem")[0];
        Assert.Equal("inProgress", item.GetProperty("state").GetString());
        Assert.Equal("AcceptedByBTWwBC", item.GetProperty("subStatus").GetString());
    }

    [Fact]
    public async Task EmptySendUrl_SkipsSendButStillUpdatesAndReschedules()
    {
        var h = Create(Order(Item("1")), new SimulationOptions { SendUrl = "" });

        await h.RunAsync();

        Assert.Empty(h.Http.Requests);
        Assert.Equal(1, h.Repository.UpdateCount);
        Assert.Single(h.Jobs.Created);
    }

    [Fact]
    public async Task FailedSend_Throws_AndDoesNotReschedule()
    {
        var h = Create(Order(Item("1")), status: HttpStatusCode.InternalServerError);

        await Assert.ThrowsAsync<HttpRequestException>(h.RunAsync);

        Assert.Empty(h.Jobs.Created);
    }

    [Theory]
    [InlineData("Acknowledged", null)]
    [InlineData("acknowledged", null)]
    [InlineData("InProgress", ProductOrderItemState.Acknowledged)]
    public async Task StageReturnFailure_MatchingState_FailsItem(string stage, ProductOrderItemState? start)
    {
        var h = Create(Order(Item("1", start)), new SimulationOptions { SendUrl = Url, StageReturnFailure = stage });

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.Failed, h.Order.Items[0].State);
        Assert.Empty(h.Jobs.Created);
    }

    [Fact]
    public async Task StageReturnFailure_MatchingSubStatus_FailsItemAndSendsFailedState()
    {
        var h = Create(Order(Item("1", ProductOrderItemState.InProgress, "AcceptedByBTWwBC")), new SimulationOptions { SendUrl = Url, StageReturnFailure = "AwaitingECCConfirmation" });

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.Failed, h.Order.Items[0].State);
        Assert.Equal("AwaitingECCConfirmation", h.Order.Items[0].SubStatus);
        Assert.Contains("\"state\":\"failed\"", Assert.Single(h.Http.Requests).Body);
        Assert.Empty(h.Jobs.Created);
    }

    [Fact]
    public async Task StageReturnFailure_NotMatching_ProgressesNormally()
    {
        var h = Create(Order(Item("1")), new SimulationOptions { SendUrl = Url, StageReturnFailure = "Completed" });

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.Acknowledged, h.Order.Items[0].State);
    }

    [Fact]
    public async Task StageReturnFailure_Blank_DoesNotFail()
    {
        var h = Create(Order(Item("1")), new SimulationOptions { SendUrl = Url, StageReturnFailure = "  " });

        await h.RunAsync();

        Assert.Equal(ProductOrderItemState.Acknowledged, h.Order.Items[0].State);
    }
}
