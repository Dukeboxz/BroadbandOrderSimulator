namespace BroadbandSupplierSimulator.Simulation;

public class SimulationOptions
{
    public const string SectionName = "Simulation";

    public Dictionary<string, EndpointSimulationSettings> Endpoints { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public class EndpointSimulationSettings
{
    public bool SendFailure { get; set; }

    public int ResponseDelayMs { get; set; }

    public bool AppointmentAvailable { get; set; } = true;
}
