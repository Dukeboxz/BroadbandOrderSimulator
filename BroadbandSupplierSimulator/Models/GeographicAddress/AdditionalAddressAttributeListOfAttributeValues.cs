using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class AdditionalAddressAttributeListOfAttributeValues
{
    [JsonPropertyName("attributeValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string>? AttributeValue { get; set; }
}
