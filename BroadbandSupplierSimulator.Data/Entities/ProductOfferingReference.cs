using System.ComponentModel.DataAnnotations.Schema;

namespace BroadbandSupplierSimulator.Data.Entities;

[ComplexType]
public class ProductOfferingReference
{
    public required string OfferingId { get; set; }
    public string? Name { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public string? ProductFamily { get; set; }
}
