using Microsoft.Extensions.Options;

namespace BroadbandSupplierSimulator.Simulation;

public class SimulationHelper(IOptionsMonitor<SimulationOptions> options) : ISimulationHelper
{
    public EndpointSimulationSettings GetSettings(string endpointName)
    {
        return options.CurrentValue.Endpoints.TryGetValue(endpointName, out var settings) ? settings : new EndpointSimulationSettings();
    }

    public int GetResponseDelayMs(string endpointName)
    {
        return Math.Max(0, GetSettings(endpointName).ResponseDelayMs);
    }

    public async Task DelayResponseAsync(string endpointName, CancellationToken cancellationToken = default)
    {
        var delayMs = GetResponseDelayMs(endpointName);

        if (delayMs > 0)
        {
            await Task.Delay(delayMs, cancellationToken);
        }
    }
}
