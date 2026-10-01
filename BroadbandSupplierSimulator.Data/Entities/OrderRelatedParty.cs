namespace BroadbandSupplierSimulator.Data.Entities;

public class OrderRelatedParty
{
    public Guid Id { get; set; }
    public Guid? ProductOrderId { get; set; }
    public ProductOrder? ProductOrder { get; set; }
    public Guid? OrderProductId { get; set; }
    public OrderProduct? OrderProduct { get; set; }
    public required string PartyId { get; set; }
    public string? Name { get; set; }
    public string? Role { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public required string ReferredType { get; set; }
    public string? FamilyName { get; set; }
    public string? GivenName { get; set; }
    public string? Title { get; set; }
    public List<OrderContactMedium> ContactMedia { get; set; } = [];
}
