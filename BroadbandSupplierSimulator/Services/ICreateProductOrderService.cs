using BroadbandSupplierSimulator.Models.ProductOrder;
using BroadbandSupplierSimulator.Validation;

namespace BroadbandSupplierSimulator.Services;

public interface ICreateProductOrderService
{
    OrderValidationResult CreateProductOrder(ProductOrderCreate payload);
}
