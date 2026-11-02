using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Simulation;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MessageSubStatus
{
    Acknowledged,
    AcceptedByBTWwBC,
    AmendedByBTWwBC,
    AwaitingECCConfirmation,
    CancellationRequest,
    CancellationAccepted,
    CancellationRejected,
    Cancelled,
    CancelledBTWwBCService,
    Closed,
    CommittedByBTWwBC,
    CompletedBTWwBCService,
    DelayedBySupplier,
    DisconnectEsideCopperByBTWwbc,
    ECCApply,
    ECCReminder,
    Failed,
    FailedBTWwBCService,
    FlaggedForAttention,
    InProgressWithSpace,
    InProgress,
    NoBillingFulfilmentRequired,
    NoFulfillment,
    NoORDSSRMServiceRequired,
    PendingWithBTWwBC,
    Rejected
}

public static class MessageSubStatusExtensions
{
    /// <summary>The sub status text sent to, and stored for, an order item.</summary>
    public static string ToValue(this MessageSubStatus subStatus) => subStatus switch
    {
        MessageSubStatus.Acknowledged => "acknowledged",
        MessageSubStatus.CancellationRequest => "Cancellation Request",
        MessageSubStatus.InProgressWithSpace => "In Progress",
        MessageSubStatus.InProgress => "inProgress",
        MessageSubStatus.Rejected => "rejected",
        _ => subStatus.ToString()
    };
}
