namespace BroadbandSupplierSimulator.Data.Entities;

public enum ProductOrderItemState
{
    Acknowledged,
    Rejected,
    Pending,
    Held,
    InProgress,
    Cancelled,
    Completed,
    Failed,
    AssessingCancellation,
    PendingCancellation
}
