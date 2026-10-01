using Entity = BroadbandSupplierSimulator.Data.Entities;
using Payload = BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public static class RelatedPartyMapper
{
    public static Entity.OrderRelatedParty ToEntity(Payload.BTRelatedParty source)
    {
        return new Entity.OrderRelatedParty
        {
            PartyId = source.Id,
            Name = source.Name,
            Role = source.Role,
            BaseType = source.BaseType,
            Type = source.Type,
            ReferredType = source.ReferredType,
            FamilyName = source.FamilyName,
            GivenName = source.GivenName,
            Title = source.Title,
            ContactMedia = source.ContactMedium?.Select(ToEntity).ToList() ?? []
        };
    }

    public static List<Entity.OrderRelatedParty> ToEntities(IEnumerable<Payload.BTRelatedParty>? source)
    {
        return source?.Select(ToEntity).ToList() ?? [];
    }

    private static Entity.OrderContactMedium ToEntity(Payload.BTContactMedium source)
    {
        return new Entity.OrderContactMedium
        {
            MediumType = source.MediumType,
            ContactType = source.Characteristic?.ContactType,
            PhoneNumber = source.Characteristic?.PhoneNumber,
            FaxNumber = source.Characteristic?.FaxNumber,
            EmailAddress = source.Characteristic?.EmailAddress,
            Address = AddressMapper.ToEntity(source.Characteristic?.Address)
        };
    }
}
