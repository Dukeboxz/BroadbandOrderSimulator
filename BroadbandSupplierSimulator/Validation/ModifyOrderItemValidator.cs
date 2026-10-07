using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Validation;

public class ModifyOrderItemValidator : ProductIdRequiredOrderItemValidator
{
    public override OrderItemActionType Action => OrderItemActionType.Modify;
}
