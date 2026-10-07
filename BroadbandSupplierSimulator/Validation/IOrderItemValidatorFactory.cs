using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Validation;

public interface IOrderItemValidatorFactory
{
    IOrderItemValidator GetValidator(OrderItemActionType action);
}
