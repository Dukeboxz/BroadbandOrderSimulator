using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class AmendProductOrderRequestProductOrderItemProductOrderItemProduct
{
    [JsonPropertyName("productOffering")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AmendProductOrderRequestProductOrderItemProductOrderItemProductProductOffering? ProductOffering { get; set; }

    [JsonPropertyName("productCharacteristic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<AmendProductOrderRequestProductOrderItemProductOrderItemProductProductCharacteristic>? ProductCharacteristic { get; set; }

    [JsonPropertyName("@type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }
}
