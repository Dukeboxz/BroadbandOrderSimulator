using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Data.Entities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductOrderItemState
{
    Acknowledged,
    Rejected,
    Pending,
    Held,
    InProgress,
    Cancelled,
    Completed,
    Failed,
    AssessingCancellation,
    PendingCancellation
}
