using Entity = BroadbandSupplierSimulator.Data.Entities;
using Payload = BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public static class AddressMapper
{
    public static Entity.PostalAddress ToEntity(Payload.GeographicAddress? source)
    {
        if (source is null)
        {
            return new Entity.PostalAddress();
        }

        return new Entity.PostalAddress
        {
            AddressId = source.Id,
            MatchedId = source.MatchedId,
            AddressMatch = source.AddressMatch,
            Uprn = source.Uprn,
            ParentUprn = source.ParentUPRN,
            AddressSource = source.AddressSource,
            ExchangeGroupCode = source.ExchangeGroupCode,
            DistrictCode = source.DistrictCode,
            Qualifier = source.Qualifier,
            StreetNr = source.StreetNr,
            StreetNrSuffix = source.StreetNrSuffix,
            StreetNrLast = source.StreetNrLast,
            StreetNrLastSuffix = source.StreetNrLastSuffix,
            StreetName = source.StreetName,
            StreetType = source.StreetType,
            StreetSuffix = source.StreetSuffix,
            Postcode = source.Postcode,
            Locality = source.Locality,
            City = source.City,
            StateOrProvince = source.StateOrProvince,
            Country = source.Country,
            Location = ToEntity(source.GeographicLocationRefOrValue),
            SubAddress = ToEntity(source.GeographicSubAddress)
        };
    }

    private static Entity.GeographicLocationValue ToEntity(Payload.GeographicLocation? source)
    {
        if (source is null)
        {
            return new Entity.GeographicLocationValue();
        }

        return new Entity.GeographicLocationValue
        {
            LocationId = source.Id,
            Name = source.Name,
            GeometryType = source.GeometryType,
            Accuracy = source.Accuracy,
            SpatialRef = source.SpatialRef,
            X = source.Geometry?.X,
            Y = source.Geometry?.Y,
            Z = source.Geometry?.Z
        };
    }

    private static Entity.GeographicSubAddressValue ToEntity(Payload.GeographicSubAddress? source)
    {
        if (source is null)
        {
            return new Entity.GeographicSubAddressValue();
        }

        return new Entity.GeographicSubAddressValue
        {
            SubAddressId = source.Id,
            Name = source.Name,
            SubUnitType = source.SubUnitType,
            SubUnitNumber = source.SubUnitNumber,
            LevelType = source.LevelType,
            LevelNumber = source.LevelNumber,
            BuildingName = source.BuildingName,
            PrivateStreetNumber = source.PrivateStreetNumber,
            PrivateStreetName = source.PrivateStreetName
        };
    }
}
