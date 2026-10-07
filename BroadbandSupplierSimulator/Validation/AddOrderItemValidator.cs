using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Validation;

public class AddOrderItemValidator : IOrderItemValidator
{
    public OrderItemActionType Action => OrderItemActionType.Add;

    public OrderValidationResult Validate(BTProductOrderItem item)
    {
        var result = new OrderValidationResult();

        if (item.Product?.ProductCharacteristic is not { Count: > 0 })
        {
            result.AddError($"productOrderItem '{item.Id}': product.productCharacteristic must not be null or empty for action '{item.Action}'.");
        }

        return result;
    }
}
