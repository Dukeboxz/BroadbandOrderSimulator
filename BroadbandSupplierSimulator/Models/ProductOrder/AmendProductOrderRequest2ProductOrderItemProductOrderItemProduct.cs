using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class AmendProductOrderRequest2ProductOrderItemProductOrderItemProduct
{
    [JsonPropertyName("productOffering")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AmendProductOrderRequest2ProductOrderItemProductOrderItemProductProductOffering? ProductOffering { get; set; }

    [JsonPropertyName("productCharacteristic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<AmendProductOrderRequest2ProductOrderItemProductOrderItemProductProductCharacteristic>? ProductCharacteristic { get; set; }

    [JsonPropertyName("@type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }
}
