using BroadbandSupplierSimulator.Mappers;
using BroadbandSupplierSimulator.Models.ProductOrder;
using BroadbandSupplierSimulator.Validation;

namespace BroadbandSupplierSimulator.Services;

public class CreateProductOrderService(IOrderItemValidatorFactory validatorFactory, IProductOrderCreateMapper mapper) : ICreateProductOrderService
{
    public OrderValidationResult CreateProductOrder(ProductOrderCreate payload)
    {
        var result = new OrderValidationResult();

        foreach (var item in payload.ProductOrderItem)
        {
            result.Merge(validatorFactory.GetValidator(item.Action).Validate(item));
        }

        if (result.IsValid)
        {
            var eventPayload = mapper.MapToProductOrderCreateEvent(payload);
        }

        return result;
    }
}
