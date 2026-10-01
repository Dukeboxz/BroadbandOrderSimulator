namespace BroadbandSupplierSimulator.Data.Entities;

public class OrderPlace
{
    public Guid Id { get; set; }
    public Guid OrderProductId { get; set; }
    public OrderProduct OrderProduct { get; set; } = null!;
    public string? PlaceId { get; set; }
    public string? Name { get; set; }
    public required string Role { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public PostalAddress Address { get; set; } = new();
}
