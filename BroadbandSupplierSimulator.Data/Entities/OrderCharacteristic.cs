namespace BroadbandSupplierSimulator.Data.Entities;

public class OrderCharacteristic
{
    public Guid Id { get; set; }
    public Guid OrderProductId { get; set; }
    public OrderProduct OrderProduct { get; set; } = null!;
    public required string Name { get; set; }
    public string? ValueType { get; set; }
    public required string Value { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public string? PreviousValue { get; set; }
    public OrderItemAction? Action { get; set; }
}
