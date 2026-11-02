using BroadbandSupplierSimulator.Models.SimulatorOptions;

namespace BroadbandSupplierSimulator.Validation;

public interface ISetSimulationOptionsValidator
{
    OrderValidationResult Validate(SetSimulationOptionsRequest request);
}
