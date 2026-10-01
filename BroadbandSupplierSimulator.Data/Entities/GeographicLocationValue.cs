using System.ComponentModel.DataAnnotations.Schema;

namespace BroadbandSupplierSimulator.Data.Entities;

[ComplexType]
public class GeographicLocationValue
{
    public string? LocationId { get; set; }
    public string? Name { get; set; }
    public string? GeometryType { get; set; }
    public string? Accuracy { get; set; }
    public string? SpatialRef { get; set; }
    public string? X { get; set; }
    public string? Y { get; set; }
    public string? Z { get; set; }
}
