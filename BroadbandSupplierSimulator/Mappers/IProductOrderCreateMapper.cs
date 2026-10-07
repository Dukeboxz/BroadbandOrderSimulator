using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public interface IProductOrderCreateMapper
{
    ProductOrderCreateEventPayload MapToProductOrderCreateEvent(ProductOrderCreate payload);
}
