namespace BroadbandSupplierSimulator.Data.Entities;

public class ProductOrderItem
{
    public Guid Id { get; set; }
    public Guid ProductOrderId { get; set; }
    public ProductOrder ProductOrder { get; set; } = null!;
    public Guid? ParentItemId { get; set; }
    public ProductOrderItem? ParentItem { get; set; }
    public required string ItemId { get; set; }
    public OrderItemAction Action { get; set; }
    public ProductOrderItemState? State { get; set; }
    public string? SubStatus { get; set; }
    public string? InternalId { get; set; }
    public PointOfNoReturnStatus? AmendmentStatus { get; set; }
    public PointOfNoReturnStatus? CancellationStatus { get; set; }
    public DateTimeOffset? RequestedCompletionDate { get; set; }
    public DateTimeOffset? ExpectedCompletionDate { get; set; }
    public DateTimeOffset? CompletionDate { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public BillingAccountReference? BillingAccount { get; set; }
    public ProductOfferingReference? ProductOffering { get; set; }
    public AppointmentReference? Appointment { get; set; }
    public QualificationItemReference? ProductOfferingQualificationItem { get; set; }
    public OrderProduct? Product { get; set; }
    public List<OrderNote> Notes { get; set; } = [];
    public List<ProductOrderItem> ChildItems { get; set; } = [];
    public List<OrderItemRelationship> Relationships { get; set; } = [];
    public List<OrderQualification> Qualifications { get; set; } = [];
}
