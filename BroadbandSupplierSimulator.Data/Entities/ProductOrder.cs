namespace BroadbandSupplierSimulator.Data.Entities;

public class ProductOrder
{
    public Guid Id { get; set; }
    public string? ExternalId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset? RequestedCompletionDate { get; set; }
    public DateTimeOffset ReceivedAt { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public BillingAccountReference? BillingAccount { get; set; }
    public List<OrderNote> Notes { get; set; } = [];
    public List<OrderRelatedParty> RelatedParties { get; set; } = [];
    public List<ProductOrderItem> Items { get; set; } = [];
}
