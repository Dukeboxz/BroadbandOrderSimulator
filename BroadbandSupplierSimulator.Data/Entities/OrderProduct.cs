namespace BroadbandSupplierSimulator.Data.Entities;

public class OrderProduct
{
    public Guid Id { get; set; }
    public Guid? ProductOrderItemId { get; set; }
    public ProductOrderItem? ProductOrderItem { get; set; }
    public Guid? ProductRelationshipId { get; set; }
    public ProductRelationship? ProductRelationship { get; set; }
    public string? ProductId { get; set; }
    public string? Name { get; set; }
    public string? ProductSerialNumber { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? TerminationDate { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public string? PreviousId { get; set; }
    public ProductOfferingReference? ProductOffering { get; set; }
    public ServiceIdentifier CustomerFacingServiceId { get; set; } = new();
    public List<OrderPlace> Places { get; set; } = [];
    public List<OrderCharacteristic> Characteristics { get; set; } = [];
    public List<ProductRelationship> Relationships { get; set; } = [];
    public List<OrderRelatedParty> RelatedParties { get; set; } = [];
}
