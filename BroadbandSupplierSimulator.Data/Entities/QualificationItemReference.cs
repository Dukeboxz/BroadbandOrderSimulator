using System.ComponentModel.DataAnnotations.Schema;

namespace BroadbandSupplierSimulator.Data.Entities;

[ComplexType]
public class QualificationItemReference
{
    public required string ItemId { get; set; }
    public required string QualificationId { get; set; }
    public string? QualificationName { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public string? ReferredType { get; set; }
}
