using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderItemActionType
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
