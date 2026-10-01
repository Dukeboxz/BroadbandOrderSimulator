namespace BroadbandSupplierSimulator.Data.Entities;

public class OrderNote
{
    public Guid Id { get; set; }
    public Guid? ProductOrderId { get; set; }
    public ProductOrder? ProductOrder { get; set; }
    public Guid? ProductOrderItemId { get; set; }
    public ProductOrderItem? ProductOrderItem { get; set; }
    public NoteKind Kind { get; set; }
    public string? NoteId { get; set; }
    public required string Text { get; set; }
    public string? NoteType { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
}
