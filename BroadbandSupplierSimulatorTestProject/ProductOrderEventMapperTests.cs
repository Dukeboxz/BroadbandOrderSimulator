using BroadbandSupplierSimulator.Data.Entities;
using BroadbandSupplierSimulator.Mappers;
using BroadbandSupplierSimulator.Models.ProductOrder;
using Entity = BroadbandSupplierSimulator.Data.Entities;

namespace BroadbandSupplierSimulatorTestProject;

public class ProductOrderEventMapperTests
{
    private static Entity.ProductOrderItem Item(string id, ProductOrderItemState? state, Entity.ProductOrderItem? parent = null)
    {
        var item = new Entity.ProductOrderItem { Id = Guid.NewGuid(), ItemId = id, State = state, Action = OrderItemAction.Add };
        if (parent is not null)
        {
            item.ParentItem = parent;
            item.ParentItemId = parent.Id;
            parent.ChildItems.Add(item);
        }

        return item;
    }

    private static BTProductOrder Map(params Entity.ProductOrderItem[] items) =>
        ProductOrderEventMapper.ToEvent(new Entity.ProductOrder { Id = Guid.NewGuid(), Items = [.. items] }).Event!.ProductOrder!;

    [Fact]
    public void ToEvent_PopulatesEnvelope()
    {
        var order = new Entity.ProductOrder { Id = Guid.NewGuid(), ExternalId = "ext", Items = [Item("1", null)] };

        var evt = ProductOrderEventMapper.ToEvent(order);

        Assert.False(string.IsNullOrEmpty(evt.EventId));
        Assert.NotNull(evt.EventTime);
        Assert.Equal(ProductOrderEventMapper.EventType, evt.EventType);
        Assert.Equal(order.Id.ToString(), evt.Event!.ProductOrder!.Id);
        Assert.Equal("ext", evt.Event.ProductOrder.ExternalId);
    }

    [Fact]
    public void ToEvent_NestsChildItemsUnderParent_AndOnlyTopLevelAtRoot()
    {
        var parent = Item("1", ProductOrderItemState.InProgress);
        var child = Item("1.1", ProductOrderItemState.Acknowledged, parent);

        var order = Map(parent, child);

        var root = Assert.Single(order.ProductOrderItem);
        Assert.Equal("1", root.Id);
        var nested = Assert.Single(root.ProductOrderItem!);
        Assert.Equal("1.1", nested.Id);
        Assert.Equal(ProductOrderItemStateType.Acknowledged, nested.State);
    }

    [Fact]
    public void ToEvent_MapsItemStateAndSubStatus()
    {
        var item = Item("1", ProductOrderItemState.InProgress);
        item.SubStatus = "CommittedByBTWwBC";

        var mapped = Assert.Single(Map(item).ProductOrderItem);

        Assert.Equal(ProductOrderItemStateType.InProgress, mapped.State);
        Assert.Equal("CommittedByBTWwBC", mapped.SubStatus);
        Assert.Equal(OrderItemActionType.Add, mapped.Action);
    }

    [Theory]
    [InlineData(new[] { ProductOrderItemState.Completed, ProductOrderItemState.Completed }, ProductOrderStateType.Completed)]
    [InlineData(new[] { ProductOrderItemState.Acknowledged, ProductOrderItemState.Acknowledged }, ProductOrderStateType.Acknowledged)]
    [InlineData(new[] { ProductOrderItemState.Acknowledged, ProductOrderItemState.InProgress }, ProductOrderStateType.InProgress)]
    [InlineData(new[] { ProductOrderItemState.Completed, ProductOrderItemState.InProgress }, ProductOrderStateType.InProgress)]
    public void ToEvent_DerivesOrderState(ProductOrderItemState[] states, ProductOrderStateType expected)
    {
        var order = Map(states.Select((s, i) => Item(i.ToString(), s)).ToArray());

        Assert.Equal(expected, order.State);
    }
}
