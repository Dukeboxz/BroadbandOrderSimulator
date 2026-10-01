using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductStatusType
{
    [JsonStringEnumMemberName("created")]
    Created,
    [JsonStringEnumMemberName("pendingActive")]
    PendingActive,
    [JsonStringEnumMemberName("cancelled")]
    Cancelled,
    [JsonStringEnumMemberName("active")]
    Active,
    [JsonStringEnumMemberName("pendingTerminate")]
    PendingTerminate,
    [JsonStringEnumMemberName("terminated")]
    Terminated,
    [JsonStringEnumMemberName("suspended")]
    Suspended,
    [JsonStringEnumMemberName("aborted ")]
    Aborted
}
