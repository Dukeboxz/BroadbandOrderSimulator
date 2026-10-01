using Entity = BroadbandSupplierSimulator.Data.Entities;
using Payload = BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public static class ReferenceMapper
{
    public static Entity.BillingAccountReference? ToEntity(Payload.BillingAccountRefs? source)
    {
        if (source is null)
        {
            return null;
        }

        return new Entity.BillingAccountReference
        {
            AccountId = source.Id,
            BaseType = source.BaseType,
            Type = source.Type
        };
    }

    public static Entity.ProductOfferingReference? ToEntity(Payload.BTProductOfferingRef? source)
    {
        if (source is null)
        {
            return null;
        }

        return new Entity.ProductOfferingReference
        {
            OfferingId = source.Id,
            Name = source.Name,
            BaseType = source.BaseType,
            Type = source.Type,
            ProductFamily = source.ProductFamily
        };
    }

    public static Entity.AppointmentReference? ToEntity(Payload.BTAppointmentRef? source)
    {
        if (source is null)
        {
            return null;
        }

        return new Entity.AppointmentReference
        {
            AppointmentId = source.Id,
            Description = source.Description,
            BaseType = source.BaseType,
            Type = source.Type,
            AppointmentStart = MapperHelpers.ToUtc(source.AppointmentStart),
            AppointmentFinish = MapperHelpers.ToUtc(source.AppointmentFinish),
            AppointmentStatus = source.AppointmentStatus,
            BesAppointmentId = source.BESAppointmentId
        };
    }

    public static Entity.QualificationItemReference? ToEntity(Payload.ProductOfferingQualificationItemRef? source)
    {
        if (source is null)
        {
            return null;
        }

        return new Entity.QualificationItemReference
        {
            ItemId = source.Id,
            QualificationId = source.ProductOfferingQualificationId,
            QualificationName = source.ProductOfferingQualificationName,
            BaseType = source.BaseType,
            Type = source.Type,
            ReferredType = source.ReferredType
        };
    }

    public static Entity.ServiceIdentifier ToEntity(Payload.BTServiceId? source)
    {
        return new Entity.ServiceIdentifier
        {
            Value = source?.Value,
            PreviousValue = source?.PreviousValue
        };
    }

    public static Entity.OrderItemRelationship ToEntity(Payload.OrderItemRelationship source)
    {
        return new Entity.OrderItemRelationship
        {
            RelationshipId = source.Id,
            RelationshipType = source.RelationshipType,
            BaseType = source.BaseType,
            Type = source.Type
        };
    }

    public static Entity.OrderQualification ToEntity(Payload.ProductOfferingQualificationRef source)
    {
        return new Entity.OrderQualification
        {
            QualificationId = source.Id,
            Name = source.Name,
            BaseType = source.BaseType,
            Type = source.Type,
            ReferredType = source.ReferredType
        };
    }
}
