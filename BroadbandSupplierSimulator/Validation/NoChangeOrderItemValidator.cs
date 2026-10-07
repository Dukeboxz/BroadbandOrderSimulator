using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Validation;

public class NoChangeOrderItemValidator : IOrderItemValidator
{
    public OrderItemActionType Action => OrderItemActionType.NoChange;

    public OrderValidationResult Validate(BTProductOrderItem item)
    {
        return new OrderValidationResult();
    }
}
