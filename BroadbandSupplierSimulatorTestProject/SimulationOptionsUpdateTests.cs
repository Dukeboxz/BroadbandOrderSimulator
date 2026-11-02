using System.Text.Json;
using BroadbandSupplierSimulator.Data.Entities;
using BroadbandSupplierSimulator.Models.SimulatorOptions;
using BroadbandSupplierSimulator.Simulation;
using BroadbandSupplierSimulator.Validation;
using Microsoft.Extensions.Options;

namespace BroadbandSupplierSimulatorTestProject;

public class SetSimulationOptionsValidatorTests
{
    private static IReadOnlyList<string> Errors(SetSimulationOptionsRequest request) =>
        new SetSimulationOptionsValidator().Validate(request).Errors;

    [Fact]
    public void EmptyRequest_IsValid()
    {
        Assert.Empty(Errors(new SetSimulationOptionsRequest()));
    }

    [Fact]
    public void ValidRequest_IsValid()
    {
        var request = new SetSimulationOptionsRequest
        {
            StageReturnFailure = "CommittedByBTWwBC",
            MessageGapMs = 500,
            SendUrl = "https://example.com/notify",
            MessageOrder =
            [
                new() { SequenceOrder = 1, State = ProductOrderItemState.Acknowledged },
                new() { SequenceOrder = 2, State = ProductOrderItemState.InProgress, SubStatus = MessageSubStatus.AwaitingECCConfirmation }
            ],
            Endpoints = new()
            {
                ["createProductOrder"] = new() { SendFailure = true, ResponseDelayMs = 100 },
                ["SearchTimeSlot"] = new() { AppointmentAvailable = false }
            }
        };

        Assert.Empty(Errors(request));
    }

    [Theory]
    [InlineData("")]
    [InlineData("Completed")]
    [InlineData("in progress")]
    [InlineData("AcceptedByBTWwBC")]
    public void StageReturnFailure_KnownOrEmpty_IsValid(string stage)
    {
        Assert.Empty(Errors(new SetSimulationOptionsRequest { StageReturnFailure = stage }));
    }

    [Theory]
    [InlineData("NotAStage")]
    [InlineData("3")]
    public void StageReturnFailure_Unknown_IsInvalid(string stage)
    {
        Assert.Single(Errors(new SetSimulationOptionsRequest { StageReturnFailure = stage }));
    }

    [Fact]
    public void NegativeMessageGapMs_IsInvalid()
    {
        Assert.Single(Errors(new SetSimulationOptionsRequest { MessageGapMs = -1 }));
    }

    [Theory]
    [InlineData("not a url")]
    [InlineData("/relative")]
    [InlineData("ftp://example.com")]
    public void SendUrl_NotHttp_IsInvalid(string url)
    {
        Assert.Single(Errors(new SetSimulationOptionsRequest { SendUrl = url }));
    }

    [Fact]
    public void SendUrl_Empty_IsValid()
    {
        Assert.Empty(Errors(new SetSimulationOptionsRequest { SendUrl = "" }));
    }

    [Fact]
    public void MessageOrder_InvalidEntries_ReportEachError()
    {
        var request = new SetSimulationOptionsRequest
        {
            MessageOrder =
            [
                new() { SequenceOrder = 1, State = (ProductOrderItemState)99, SubStatus = (MessageSubStatus)99 },
                new() { State = null },
                new() { SequenceOrder = 1, State = ProductOrderItemState.Completed }
            ]
        };

        var errors = Errors(request);

        Assert.Equal(5, errors.Count);
        Assert.Contains(errors, e => e.Contains("SequenceOrder 1 is used more than once"));
    }

    [Fact]
    public void UnknownEndpoint_IsInvalid()
    {
        var request = new SetSimulationOptionsRequest { Endpoints = new() { ["Nope"] = new() { SendFailure = true } } };

        Assert.Single(Errors(request));
    }

    [Fact]
    public void NegativeResponseDelay_IsInvalid()
    {
        var request = new SetSimulationOptionsRequest { Endpoints = new() { ["GetProduct"] = new() { ResponseDelayMs = -1 } } };

        Assert.Single(Errors(request));
    }

    [Fact]
    public void AppointmentAvailable_OnOtherEndpoint_IsInvalid()
    {
        var request = new SetSimulationOptionsRequest { Endpoints = new() { ["GetProduct"] = new() { AppointmentAvailable = true } } };

        Assert.Single(Errors(request));
    }
}

public class SimulationOptionsUpdateHandlerTests
{
    private static (SimulationOptionsUpdateHandler Handler, OptionsMonitor<SimulationOptions> Monitor) Create(Action<SimulationOptions> configure)
    {
        var cache = new OptionsCache<SimulationOptions>();
        var handler = new SimulationOptionsUpdateHandler(cache);
        var factory = new OptionsFactory<SimulationOptions>(
            [new ConfigureOptions<SimulationOptions>(configure)],
            [handler]);
        return (handler, new OptionsMonitor<SimulationOptions>(factory, [], cache));
    }

    [Fact]
    public void Apply_UpdatesOnlyFieldsPresent()
    {
        var (handler, monitor) = Create(o =>
        {
            o.SendUrl = "http://original";
            o.MessageGapMs = 10;
            o.StageReturnFailure = "Completed";
            o.Endpoints["CreateProductOrder"] = new EndpointSimulationSettings { SendFailure = false, ResponseDelayMs = 50 };
        });

        Assert.Equal(10, monitor.CurrentValue.MessageGapMs);

        handler.Apply(new SetSimulationOptionsRequest
        {
            MessageGapMs = 2000,
            Endpoints = new() { ["createproductorder"] = new() { SendFailure = true } }
        });

        var current = monitor.CurrentValue;
        Assert.Equal(2000, current.MessageGapMs);
        Assert.Equal("http://original", current.SendUrl);
        Assert.Equal("Completed", current.StageReturnFailure);
        Assert.True(current.Endpoints["CreateProductOrder"].SendFailure);
        Assert.Equal(50, current.Endpoints["CreateProductOrder"].ResponseDelayMs);
    }

    [Fact]
    public void Apply_AddsEndpointNotInConfiguration_WithDefaults()
    {
        var (handler, monitor) = Create(_ => { });

        handler.Apply(new SetSimulationOptionsRequest { Endpoints = new() { ["searchTimeSlot"] = new() { ResponseDelayMs = 300 } } });

        var settings = monitor.CurrentValue.Endpoints["SearchTimeSlot"];
        Assert.Equal(300, settings.ResponseDelayMs);
        Assert.False(settings.SendFailure);
        Assert.True(settings.AppointmentAvailable);
    }

    [Fact]
    public void Apply_SuccessiveUpdates_Accumulate()
    {
        var (handler, monitor) = Create(_ => { });

        handler.Apply(new SetSimulationOptionsRequest { MessageGapMs = 100 });
        handler.Apply(new SetSimulationOptionsRequest { SendUrl = "http://new" });

        Assert.Equal(100, monitor.CurrentValue.MessageGapMs);
        Assert.Equal("http://new", monitor.CurrentValue.SendUrl);
    }

    [Fact]
    public void Apply_MessageOrder_ReplacesAndEmptyClears()
    {
        var (handler, monitor) = Create(_ => { });

        handler.Apply(new SetSimulationOptionsRequest
        {
            MessageOrder = [new() { SequenceOrder = 2, State = ProductOrderItemState.InProgress, SubStatus = MessageSubStatus.CommittedByBTWwBC }]
        });

        var stage = Assert.Single(monitor.CurrentValue.MessageOrder!);
        Assert.Equal(2, stage.SequenceOrder);
        Assert.Equal(ProductOrderItemState.InProgress, stage.State);
        Assert.Equal(MessageSubStatus.CommittedByBTWwBC, stage.SubStatus);

        handler.Apply(new SetSimulationOptionsRequest { MessageOrder = [] });

        Assert.Null(monitor.CurrentValue.MessageOrder);
    }
}

public class SetSimulationOptionsRequestJsonTests
{
    [Fact]
    public void MessageOrder_EnumsDeserializeFromText()
    {
        const string json = """{ "messageOrder": [ { "sequenceOrder": 1, "state": "inProgress", "subStatus": "AwaitingECCConfirmation" } ] }""";

        var request = JsonSerializer.Deserialize<SetSimulationOptionsRequest>(json, JsonSerializerOptions.Web)!;

        var stage = Assert.Single(request.MessageOrder!);
        Assert.Equal(ProductOrderItemState.InProgress, stage.State);
        Assert.Equal(MessageSubStatus.AwaitingECCConfirmation, stage.SubStatus);
    }

    [Fact]
    public void MessageStage_EnumsSerializeAsText()
    {
        var json = JsonSerializer.Serialize(new MessageStage { SequenceOrder = 1, State = ProductOrderItemState.Completed, SubStatus = MessageSubStatus.Closed });

        Assert.Contains("\"Completed\"", json);
        Assert.Contains("\"Closed\"", json);
    }

    [Fact]
    public void UnknownEnumText_FailsToDeserialize()
    {
        const string json = """{ "messageOrder": [ { "sequenceOrder": 1, "state": "Bogus" } ] }""";

        Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<SetSimulationOptionsRequest>(json, JsonSerializerOptions.Web));
    }
}
