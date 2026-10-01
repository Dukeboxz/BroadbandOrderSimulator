using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class AmendProductOrderRequestProductOrderItemProductOrderItemProductProductOffering
{
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }
}
