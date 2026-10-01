using System.ComponentModel.DataAnnotations.Schema;

namespace BroadbandSupplierSimulator.Data.Entities;

[ComplexType]
public class GeographicSubAddressValue
{
    public string? SubAddressId { get; set; }
    public string? Name { get; set; }
    public string? SubUnitType { get; set; }
    public string? SubUnitNumber { get; set; }
    public string? LevelType { get; set; }
    public string? LevelNumber { get; set; }
    public string? BuildingName { get; set; }
    public string? PrivateStreetNumber { get; set; }
    public string? PrivateStreetName { get; set; }
}
