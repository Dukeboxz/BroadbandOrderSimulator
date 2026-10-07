using BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public class ProductOrderCreateMapper : IProductOrderCreateMapper
{
    public ProductOrderCreateEventPayload MapToProductOrderCreateEvent(ProductOrderCreate payload)
    {
        return new ProductOrderCreateEventPayload
        {
            ProductOrder = new BTProductOrder
            {
                Id = Guid.NewGuid().ToString(),
                State = ProductOrderStateType.Acknowledged,
                OrderDate = DateTimeOffset.UtcNow,
                Description = payload.Description,
                ExternalId = payload.ExternalId,
                RequestedCompletionDate = payload.RequestedCompletionDate,
                BillingAccount = payload.BillingAccount,
                Note = payload.Note,
                RelatedParty = payload.RelatedParty,
                BaseType = payload.BaseType,
                Type = payload.Type,
                ProductOrderItem = MapItems(payload.ProductOrderItem)!
            }
        };
    }

    private static List<BTProductOrderItem>? MapItems(List<BTProductOrderItem>? source)
    {
        return source?.Select(MapItem).ToList();
    }

    private static BTProductOrderItem MapItem(BTProductOrderItem source)
    {
        return new BTProductOrderItem
        {
            Id = source.Id,
            Action = source.Action,
            Appointment = source.Appointment,
            BillingAccount = source.BillingAccount,
            Product = source.Product,
            ProductOffering = source.ProductOffering,
            ProductOfferingQualificationItem = source.ProductOfferingQualificationItem,
            ProductOrderItem = MapItems(source.ProductOrderItem),
            ProductOrderItemRelationship = source.ProductOrderItemRelationship,
            Qualification = source.Qualification,
            State = ProductOrderItemStateType.Acknowledged,
            BaseType = source.BaseType,
            Type = source.Type,
            InternalId = source.InternalId,
            SubStatus = source.SubStatus,
            Note = source.Note,
            AdditionalNotes = source.AdditionalNotes,
            AmendmentStatus = source.AmendmentStatus,
            CancellationStatus = source.CancellationStatus,
            RequestedCompletionDate = source.RequestedCompletionDate,
            ExpectedCompletionDate = source.ExpectedCompletionDate,
            CompletionDate = source.CompletionDate
        };
    }
}
