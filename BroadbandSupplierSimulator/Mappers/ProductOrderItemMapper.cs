using Entity = BroadbandSupplierSimulator.Data.Entities;
using Payload = BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public static class ProductOrderItemMapper
{
    public static List<Entity.ProductOrderItem> ToEntities(IEnumerable<Payload.BTProductOrderItem> source)
    {
        var items = new List<Entity.ProductOrderItem>();

        foreach (var item in source)
        {
            Flatten(item, null, items);
        }

        return items;
    }

    private static void Flatten(Payload.BTProductOrderItem source, Entity.ProductOrderItem? parent, List<Entity.ProductOrderItem> items)
    {
        var entity = ToEntity(source);
        items.Add(entity);

        if (parent is not null)
        {
            parent.ChildItems.Add(entity);
        }

        foreach (var child in source.ProductOrderItem ?? [])
        {
            Flatten(child, entity, items);
        }
    }

    private static Entity.ProductOrderItem ToEntity(Payload.BTProductOrderItem source)
    {
        var notes = new List<Entity.OrderNote>();

        if (source.Note is not null)
        {
            notes.Add(NoteMapper.ToEntity(source.Note, Entity.NoteKind.Note));
        }

        notes.AddRange(NoteMapper.ToEntities(source.AdditionalNotes, Entity.NoteKind.AdditionalNote));

        return new Entity.ProductOrderItem
        {
            ItemId = source.Id,
            Action = MapperHelpers.ConvertEnum<Entity.OrderItemAction>(source.Action),
            State = MapperHelpers.ConvertNullableEnum<Entity.ProductOrderItemState>(source.State),
            SubStatus = source.SubStatus,
            InternalId = source.InternalId,
            AmendmentStatus = MapperHelpers.ConvertNullableEnum<Entity.PointOfNoReturnStatus>(source.AmendmentStatus),
            CancellationStatus = MapperHelpers.ConvertNullableEnum<Entity.PointOfNoReturnStatus>(source.CancellationStatus),
            RequestedCompletionDate = MapperHelpers.ToUtc(source.RequestedCompletionDate),
            ExpectedCompletionDate = MapperHelpers.ToUtc(source.ExpectedCompletionDate),
            CompletionDate = MapperHelpers.ToUtc(source.CompletionDate),
            BaseType = source.BaseType,
            Type = source.Type,
            BillingAccount = ReferenceMapper.ToEntity(source.BillingAccount),
            ProductOffering = ReferenceMapper.ToEntity(source.ProductOffering),
            Appointment = ReferenceMapper.ToEntity(source.Appointment),
            ProductOfferingQualificationItem = ReferenceMapper.ToEntity(source.ProductOfferingQualificationItem),
            Product = source.Product is null ? null : ProductMapper.ToEntity(source.Product),
            Notes = notes,
            Relationships = source.ProductOrderItemRelationship?.Select(ReferenceMapper.ToEntity).ToList() ?? [],
            Qualifications = source.Qualification?.Select(ReferenceMapper.ToEntity).ToList() ?? []
        };
    }
}
