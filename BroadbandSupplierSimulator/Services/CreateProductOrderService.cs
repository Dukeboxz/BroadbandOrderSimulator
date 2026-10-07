using BroadbandSupplierSimulator.Data;
using BroadbandSupplierSimulator.Jobs;
using BroadbandSupplierSimulator.Mappers;
using BroadbandSupplierSimulator.Models.ProductOrder;
using BroadbandSupplierSimulator.Validation;
using Hangfire;

namespace BroadbandSupplierSimulator.Services;

public class CreateProductOrderService(IOrderItemValidatorFactory validatorFactory, IProductOrderCreateMapper mapper, IRepository<BroadbandSupplierSimulator.Data.Entities.ProductOrder> repository, IBackgroundJobClient backgroundJobClient) : ICreateProductOrderService
{
    public async Task<OrderValidationResult> CreateProductOrder(ProductOrderCreate payload, CancellationToken cancellationToken = default)
    {
        var result = new OrderValidationResult();

        foreach (var item in payload.ProductOrderItem)
        {
            result.Merge(validatorFactory.GetValidator(item.Action).Validate(item));
        }

        if (result.IsValid)
        {
            var eventPayload = mapper.MapToProductOrderCreateEvent(payload);
            var entity = ProductOrderMapper.ToEntity(eventPayload.ProductOrder!);
            await repository.AddAsync(entity, cancellationToken);
            backgroundJobClient.Enqueue<IProcessProductOrderJob>(job => job.ProcessAsync(entity.Id, CancellationToken.None));
        }

        return result;
    }
}
