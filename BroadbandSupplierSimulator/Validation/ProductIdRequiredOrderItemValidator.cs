using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Validation;

public abstract class ProductIdRequiredOrderItemValidator : IOrderItemValidator
{
    public abstract OrderItemActionType Action { get; }

    public OrderValidationResult Validate(BTProductOrderItem item)
    {
        var result = new OrderValidationResult();

        if (item.Product is null)
        {
            result.AddError($"productOrderItem '{item.Id}': product must not be null for action '{item.Action}'.");
        }
        else if (string.IsNullOrWhiteSpace(item.Product.Id))
        {
            result.AddError($"productOrderItem '{item.Id}': product.id must have a value for action '{item.Action}'.");
        }

        return result;
    }
}
