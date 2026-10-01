using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class GeographicLocation
{
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }

    [JsonPropertyName("geometryType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? GeometryType { get; set; }

    [JsonPropertyName("accuracy")]
    public required string Accuracy { get; set; }

    [JsonPropertyName("spatialRef")]
    public required string SpatialRef { get; set; }

    [JsonPropertyName("geometry")]
    public required GeographicPoint Geometry { get; set; }
}
