using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductOrderItemStateType
{
    [JsonStringEnumMemberName("acknowledged")]
    Acknowledged,
    [JsonStringEnumMemberName("rejected")]
    Rejected,
    [JsonStringEnumMemberName("pending")]
    Pending,
    [JsonStringEnumMemberName("held")]
    Held,
    [JsonStringEnumMemberName("inProgress")]
    InProgress,
    [JsonStringEnumMemberName("cancelled")]
    Cancelled,
    [JsonStringEnumMemberName("completed")]
    Completed,
    [JsonStringEnumMemberName("failed")]
    Failed,
    [JsonStringEnumMemberName("assessingCancellation")]
    AssessingCancellation,
    [JsonStringEnumMemberName("pendingCancellation")]
    PendingCancellation
}
