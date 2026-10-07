using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Validation;

public interface IOrderItemValidator
{
    OrderItemActionType Action { get; }

    OrderValidationResult Validate(BTProductOrderItem item);
}
