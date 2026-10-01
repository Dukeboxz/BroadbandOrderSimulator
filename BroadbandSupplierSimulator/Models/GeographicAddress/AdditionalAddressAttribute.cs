using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class AdditionalAddressAttribute
{
    [JsonPropertyName("attributeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AttributeType { get; set; }

    [JsonPropertyName("listOfAttributeValues")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AdditionalAddressAttributeListOfAttributeValues? ListOfAttributeValues { get; set; }
}
