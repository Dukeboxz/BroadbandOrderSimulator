using BroadbandSupplierSimulator.Models.SimulatorOptions;

namespace BroadbandSupplierSimulator.Simulation;

public interface ISimulationOptionsUpdateHandler
{
    /// <summary>Applies the non-null fields of a validated request to the live simulation options.</summary>
    void Apply(SetSimulationOptionsRequest request);
}
