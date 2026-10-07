using BroadbandSupplierSimulator.Models.ProductOrder;
using BroadbandSupplierSimulator.Validation;

namespace BroadbandSupplierSimulator.Services;

public interface ICreateProductOrderService
{
    Task<OrderValidationResult> CreateProductOrder(ProductOrderCreate payload, CancellationToken cancellationToken = default);
}
