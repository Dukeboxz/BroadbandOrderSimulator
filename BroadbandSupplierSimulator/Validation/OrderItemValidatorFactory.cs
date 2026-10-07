using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Validation;

public class OrderItemValidatorFactory(IEnumerable<IOrderItemValidator> validators) : IOrderItemValidatorFactory
{
    private readonly Dictionary<OrderItemActionType, IOrderItemValidator> validatorsByAction = validators.ToDictionary(v => v.Action);

    public IOrderItemValidator GetValidator(OrderItemActionType action)
    {
        return validatorsByAction.TryGetValue(action, out var validator)
            ? validator
            : throw new InvalidOperationException($"No order item validator is registered for action '{action}'.");
    }
}
