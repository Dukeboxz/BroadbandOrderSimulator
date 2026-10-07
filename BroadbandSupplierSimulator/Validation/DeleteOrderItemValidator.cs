using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Validation;

public class DeleteOrderItemValidator : ProductIdRequiredOrderItemValidator
{
    public override OrderItemActionType Action => OrderItemActionType.Delete;
}
