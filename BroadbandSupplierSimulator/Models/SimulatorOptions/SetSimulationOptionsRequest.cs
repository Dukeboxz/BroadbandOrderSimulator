using BroadbandSupplierSimulator.Data.Entities;
using BroadbandSupplierSimulator.Simulation;

namespace BroadbandSupplierSimulator.Models.SimulatorOptions;

/// <summary>
/// Partial update of <see cref="SimulationOptions"/>. Only fields present (non-null) are applied.
/// </summary>
public class SetSimulationOptionsRequest
{
    public string? StageReturnFailure { get; set; }

    public int? MessageGapMs { get; set; }

    public string? SendUrl { get; set; }

    /// <summary>Replaces the whole message order. An empty list clears it, restoring the default progression.</summary>
    public List<SetMessageStageRequest>? MessageOrder { get; set; }

    public Dictionary<string, SetEndpointSimulationSettingsRequest>? Endpoints { get; set; }
}

public class SetMessageStageRequest
{
    public int? SequenceOrder { get; set; }

    public ProductOrderItemState? State { get; set; }

    public MessageSubStatus? SubStatus { get; set; }
}

public class SetEndpointSimulationSettingsRequest
{
    public bool? SendFailure { get; set; }

    public int? ResponseDelayMs { get; set; }

    public bool? AppointmentAvailable { get; set; }
}
