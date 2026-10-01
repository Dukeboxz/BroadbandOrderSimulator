using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ProductActionType
{
    [JsonStringEnumMemberName("add")]
    Add,
    [JsonStringEnumMemberName("modify")]
    Modify,
    [JsonStringEnumMemberName("delete")]
    Delete,
    [JsonStringEnumMemberName("noChange")]
    NoChange
}
