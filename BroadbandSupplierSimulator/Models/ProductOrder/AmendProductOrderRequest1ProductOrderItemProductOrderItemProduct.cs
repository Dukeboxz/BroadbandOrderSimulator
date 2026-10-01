using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class AmendProductOrderRequest1ProductOrderItemProductOrderItemProduct
{
    [JsonPropertyName("productOffering")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AmendProductOrderRequest1ProductOrderItemProductOrderItemProductProductOffering? ProductOffering { get; set; }
}
