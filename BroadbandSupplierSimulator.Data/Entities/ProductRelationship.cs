namespace BroadbandSupplierSimulator.Data.Entities;

public class ProductRelationship
{
    public Guid Id { get; set; }
    public Guid OrderProductId { get; set; }
    public OrderProduct OrderProduct { get; set; } = null!;
    public required string RelationshipType { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public OrderProduct? Product { get; set; }
}
