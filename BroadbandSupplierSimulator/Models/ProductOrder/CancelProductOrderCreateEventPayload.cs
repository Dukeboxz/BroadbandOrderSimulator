using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class CancelProductOrderCreateEventPayload
{
    [JsonPropertyName("cancelProductOrder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BTCancelProductOrder? CancelProductOrder { get; set; }
}
