using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class ProductOrderCreateEventPayload
{
    [JsonPropertyName("productOrder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BTProductOrder? ProductOrder { get; set; }
}
