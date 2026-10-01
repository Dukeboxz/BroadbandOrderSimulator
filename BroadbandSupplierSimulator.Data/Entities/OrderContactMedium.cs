namespace BroadbandSupplierSimulator.Data.Entities;

public class OrderContactMedium
{
    public Guid Id { get; set; }
    public Guid OrderRelatedPartyId { get; set; }
    public OrderRelatedParty OrderRelatedParty { get; set; } = null!;
    public string? MediumType { get; set; }
    public string? ContactType { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FaxNumber { get; set; }
    public string? EmailAddress { get; set; }
    public PostalAddress Address { get; set; } = new();
}
