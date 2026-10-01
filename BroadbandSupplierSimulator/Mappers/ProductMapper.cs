using Entity = BroadbandSupplierSimulator.Data.Entities;
using Payload = BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public static class ProductMapper
{
    public static Entity.OrderProduct ToEntity(Payload.BTProductRefOrValue source)
    {
        return new Entity.OrderProduct
        {
            ProductId = source.Id,
            Name = source.Name,
            ProductSerialNumber = source.ProductSerialNumber,
            StartDate = MapperHelpers.ToUtc(source.StartDate),
            TerminationDate = MapperHelpers.ToUtc(source.TerminationDate),
            BaseType = source.BaseType,
            Type = source.Type,
            PreviousId = source.PreviousId,
            ProductOffering = ReferenceMapper.ToEntity(source.ProductOffering),
            CustomerFacingServiceId = ReferenceMapper.ToEntity(source.CustomerFacingServiceId),
            Places = source.Place?.Select(ToEntity).ToList() ?? [],
            Characteristics = source.ProductCharacteristic?.Select(ToEntity).ToList() ?? [],
            Relationships = source.ProductRelationship?.Select(ToEntity).ToList() ?? [],
            RelatedParties = RelatedPartyMapper.ToEntities(source.RelatedParty)
        };
    }

    private static Entity.OrderPlace ToEntity(Payload.BTRelatedPlaceRefOrValue source)
    {
        return new Entity.OrderPlace
        {
            PlaceId = source.Id,
            Name = source.Name,
            Role = source.Role,
            BaseType = source.BaseType,
            Type = source.Type,
            Address = AddressMapper.ToEntity(source.Address)
        };
    }

    private static Entity.OrderCharacteristic ToEntity(Payload.BTCharacteristic source)
    {
        return new Entity.OrderCharacteristic
        {
            Name = source.Name,
            ValueType = source.ValueType,
            Value = source.Value,
            BaseType = source.BaseType,
            Type = source.Type,
            PreviousValue = source.PreviousValue,
            Action = MapperHelpers.ConvertNullableEnum<Entity.OrderItemAction>(source.Action)
        };
    }

    private static Entity.ProductRelationship ToEntity(Payload.ProductRelationships source)
    {
        return new Entity.ProductRelationship
        {
            RelationshipType = source.RelationshipType,
            BaseType = source.BaseType,
            Type = source.Type,
            Product = ToEntity(source.Product)
        };
    }
}
