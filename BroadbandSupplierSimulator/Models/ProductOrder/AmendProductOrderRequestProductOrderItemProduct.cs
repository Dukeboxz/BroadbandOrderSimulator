using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class AmendProductOrderRequestProductOrderItemProduct
{
    [JsonPropertyName("productOffering")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AmendProductOrderRequestProductOrderItemProductProductOffering? ProductOffering { get; set; }

    [JsonPropertyName("@type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }
}
