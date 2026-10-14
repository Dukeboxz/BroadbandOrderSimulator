namespace BroadbandSupplierSimulator.Simulation;

public class SimulationOptions
{
    public const string SectionName = "Simulation";

    public string StageReturnFailure { get; set; } = string.Empty;

    public int MessageGapMs { get; set; }

    public string SendUrl { get; set; } = string.Empty;

    public Dictionary<string, EndpointSimulationSettings> Endpoints { get; set; } = new(StringComparer.OrdinalIgnoreCase);
}

public class EndpointSimulationSettings
{
    public bool SendFailure { get; set; }

    public int ResponseDelayMs { get; set; }

    public bool AppointmentAvailable { get; set; } = true;
}
