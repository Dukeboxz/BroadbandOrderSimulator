using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class GeographicLocationRefOrValueArrayItem
{
    [JsonPropertyName("geometry")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GeographicLocationRefOrValueArrayItemGeometry>? Geometry { get; set; }

    [JsonPropertyName("spatialRef")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SpatialRef { get; set; }
}
