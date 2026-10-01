using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class AmendProductOrderRequest
{
    [JsonPropertyName("requestedCompletionDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RequestedCompletionDate { get; set; }

    [JsonPropertyName("productOrderItem")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<AmendProductOrderRequestProductOrderItem>? ProductOrderItem { get; set; }

    [JsonPropertyName("relatedParty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<AmendProductOrderRequestRelatedParty>? RelatedParty { get; set; }

    [JsonPropertyName("@type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }
}
