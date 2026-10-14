using BroadbandSupplierSimulator.Models.ProductOrder;
using Entity = BroadbandSupplierSimulator.Data.Entities;

namespace BroadbandSupplierSimulator.Mappers;

public static class ProductOrderEventMapper
{
    public const string EventType = "ProductOrderStateChangeEvent";

    public static ProductOrderCreateEvent ToEvent(Entity.ProductOrder source)
    {
        return new ProductOrderCreateEvent
        {
            EventId = Guid.NewGuid().ToString(),
            EventTime = DateTimeOffset.UtcNow,
            EventType = EventType,
            Event = new ProductOrderCreateEventPayload
            {
                ProductOrder = ToPayload(source)
            }
        };
    }

    private static BTProductOrder ToPayload(Entity.ProductOrder source)
    {
        var items = source.Items.Where(i => i.ParentItemId is null && i.ParentItem is null).Select(ToPayload).ToList();

        return new BTProductOrder
        {
            Id = source.Id.ToString(),
            ExternalId = source.ExternalId,
            Description = source.Description,
            OrderDate = source.ReceivedAt,
            RequestedCompletionDate = source.RequestedCompletionDate,
            BaseType = source.BaseType,
            Type = source.Type,
            State = GetOrderState(source.Items),
            ProductOrderItem = items
        };
    }

    private static BTProductOrderItem ToPayload(Entity.ProductOrderItem source)
    {
        var children = source.ChildItems.Select(ToPayload).ToList();

        return new BTProductOrderItem
        {
            Id = source.ItemId,
            Action = MapperHelpers.ConvertEnum<OrderItemActionType>(source.Action),
            State = MapperHelpers.ConvertNullableEnum<ProductOrderItemStateType>(source.State),
            SubStatus = source.SubStatus,
            InternalId = source.InternalId,
            AmendmentStatus = MapperHelpers.ConvertNullableEnum<PONRType>(source.AmendmentStatus),
            CancellationStatus = MapperHelpers.ConvertNullableEnum<PONRType>(source.CancellationStatus),
            RequestedCompletionDate = source.RequestedCompletionDate,
            ExpectedCompletionDate = source.ExpectedCompletionDate,
            CompletionDate = source.CompletionDate,
            BaseType = source.BaseType,
            Type = source.Type,
            ProductOrderItem = children.Count > 0 ? children : null
        };
    }

    private static ProductOrderStateType GetOrderState(IReadOnlyCollection<Entity.ProductOrderItem> items)
    {
        if (items.All(i => i.State == Entity.ProductOrderItemState.Completed))
        {
            return ProductOrderStateType.Completed;
        }

        if (items.All(i => i.State is null or Entity.ProductOrderItemState.Acknowledged))
        {
            return ProductOrderStateType.Acknowledged;
        }

        return ProductOrderStateType.InProgress;
    }
}
