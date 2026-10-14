using System.Linq.Expressions;
using System.Net;
using BroadbandSupplierSimulator.Data;
using BroadbandSupplierSimulator.Data.Entities;
using BroadbandSupplierSimulator.Simulation;
using Hangfire;
using Hangfire.Common;
using Hangfire.States;
using Microsoft.Extensions.Options;

namespace BroadbandSupplierSimulatorTestProject;

internal class FakeRepository(ProductOrder? order) : IRepository<ProductOrder>
{
    public int UpdateCount { get; private set; }

    public Task AddAsync(ProductOrder entity, CancellationToken cancellationToken = default) => Task.CompletedTask;

    public Task UpdateAsync(ProductOrder entity, CancellationToken cancellationToken = default)
    {
        UpdateCount++;
        return Task.CompletedTask;
    }

    public Task<ProductOrder?> GetAsync(Expression<Func<ProductOrder, bool>> predicate, CancellationToken cancellationToken = default, params Expression<Func<ProductOrder, object?>>[] includes)
    {
        return Task.FromResult(order is not null && predicate.Compile()(order) ? order : null);
    }
}

internal class FakeBackgroundJobClient : IBackgroundJobClient
{
    public List<(Job Job, IState State)> Created { get; } = [];

    public string Create(Job job, IState state)
    {
        Created.Add((job, state));
        return Guid.NewGuid().ToString();
    }

    public bool ChangeState(string jobId, IState state, string expectedState) => true;
}

internal class RecordingHandler(HttpStatusCode status = HttpStatusCode.Created) : HttpMessageHandler
{
    public List<(Uri? Url, string Body)> Requests { get; } = [];

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Requests.Add((request.RequestUri, request.Content is null ? "" : await request.Content.ReadAsStringAsync(cancellationToken)));
        return new HttpResponseMessage(status);
    }
}

internal class FakeHttpClientFactory(HttpMessageHandler handler) : IHttpClientFactory
{
    public HttpClient CreateClient(string name) => new(handler, disposeHandler: false);
}

internal class FakeOptionsMonitor(SimulationOptions value) : IOptionsMonitor<SimulationOptions>
{
    public SimulationOptions CurrentValue => value;

    public SimulationOptions Get(string? name) => value;

    public IDisposable? OnChange(Action<SimulationOptions, string?> listener) => null;
}
