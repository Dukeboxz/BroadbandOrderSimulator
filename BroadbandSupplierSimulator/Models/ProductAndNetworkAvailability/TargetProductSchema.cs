using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class TargetProductSchema
{
    [JsonPropertyName("@baseType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BaseType { get; set; }

    [JsonPropertyName("@schemaLocation")]
    public required string SchemaLocation { get; set; }

    [JsonPropertyName("@type")]
    public required string Type { get; set; }
}
