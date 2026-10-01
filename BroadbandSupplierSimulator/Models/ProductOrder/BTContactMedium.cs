using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class BTContactMedium
{
    [JsonPropertyName("mediumType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MediumType { get; set; }

    [JsonPropertyName("characteristic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BTMediumCharacteristic? Characteristic { get; set; }
}
