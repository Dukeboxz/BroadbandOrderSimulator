using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class EventSubscription
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("callback")]
    public required string Callback { get; set; }

    [JsonPropertyName("query")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Query { get; set; }
}
