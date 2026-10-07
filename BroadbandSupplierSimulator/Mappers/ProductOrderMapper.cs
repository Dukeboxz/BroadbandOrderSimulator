using Entity = BroadbandSupplierSimulator.Data.Entities;
using Payload = BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public static class ProductOrderMapper
{
    public static Entity.ProductOrder ToEntity(Payload.BTProductOrder source)
    {
        var entity = new Entity.ProductOrder
        {
            ExternalId = source.ExternalId,
            Description = source.Description,
            RequestedCompletionDate = MapperHelpers.ToUtc(source.RequestedCompletionDate),
            BaseType = source.BaseType,
            Type = source.Type,
            BillingAccount = ReferenceMapper.ToEntity(source.BillingAccount),
            Notes = NoteMapper.ToEntities(source.Note, Entity.NoteKind.Note),
            RelatedParties = RelatedPartyMapper.ToEntities(source.RelatedParty),
            Items = ProductOrderItemMapper.ToEntities(source.ProductOrderItem)
        };

        if (Guid.TryParse(source.Id, out var id))
        {
            entity.Id = id;
        }

        if (source.OrderDate is not null)
        {
            entity.ReceivedAt = MapperHelpers.ToUtc(source.OrderDate.Value);
        }

        return entity;
    }

    public static Entity.ProductOrder ToEntity(Payload.ProductOrderCreate source)
    {
        return new Entity.ProductOrder
        {
            ExternalId = source.ExternalId,
            Description = source.Description,
            RequestedCompletionDate = MapperHelpers.ToUtc(source.RequestedCompletionDate),
            BaseType = source.BaseType,
            Type = source.Type,
            BillingAccount = ReferenceMapper.ToEntity(source.BillingAccount),
            Notes = NoteMapper.ToEntities(source.Note, Entity.NoteKind.Note),
            RelatedParties = RelatedPartyMapper.ToEntities(source.RelatedParty),
            Items = ProductOrderItemMapper.ToEntities(source.ProductOrderItem)
        };
    }
}
