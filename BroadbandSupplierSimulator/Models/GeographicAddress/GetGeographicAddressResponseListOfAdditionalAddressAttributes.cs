using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class GetGeographicAddressResponseListOfAdditionalAddressAttributes
{
    [JsonPropertyName("additionalAddressAttribute")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<AdditionalAddressAttribute>? AdditionalAddressAttribute { get; set; }
}
