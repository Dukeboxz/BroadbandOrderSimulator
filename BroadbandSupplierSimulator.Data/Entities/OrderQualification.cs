namespace BroadbandSupplierSimulator.Data.Entities;

public class OrderQualification
{
    public Guid Id { get; set; }
    public Guid ProductOrderItemId { get; set; }
    public ProductOrderItem ProductOrderItem { get; set; } = null!;
    public required string QualificationId { get; set; }
    public string? Name { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public string? ReferredType { get; set; }
}
