namespace BroadbandSupplierSimulator.Simulation;

public interface ISimulationHelper
{
    EndpointSimulationSettings GetSettings(string endpointName);

    int GetResponseDelayMs(string endpointName);

    Task DelayResponseAsync(string endpointName, CancellationToken cancellationToken = default);
}
