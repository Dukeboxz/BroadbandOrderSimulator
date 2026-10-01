namespace BroadbandSupplierSimulator.Data.Entities;

public class OrderItemRelationship
{
    public Guid Id { get; set; }
    public Guid ProductOrderItemId { get; set; }
    public ProductOrderItem ProductOrderItem { get; set; } = null!;
    public string? RelationshipId { get; set; }
    public string? RelationshipType { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
}
