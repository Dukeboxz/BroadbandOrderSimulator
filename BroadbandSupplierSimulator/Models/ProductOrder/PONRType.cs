using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PONRType
{
    [JsonStringEnumMemberName("Allowed")]
    Allowed,
    [JsonStringEnumMemberName("NotAllowed")]
    NotAllowed,
    [JsonStringEnumMemberName("VerificationRequired")]
    VerificationRequired
}
