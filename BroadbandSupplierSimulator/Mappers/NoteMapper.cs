using Entity = BroadbandSupplierSimulator.Data.Entities;
using Payload = BroadbandSupplierSimulator.Models.ProductOrder;

namespace BroadbandSupplierSimulator.Mappers;

public static class NoteMapper
{
    public static Entity.OrderNote ToEntity(Payload.BTNote source, Entity.NoteKind kind)
    {
        return new Entity.OrderNote
        {
            Kind = kind,
            NoteId = source.Id,
            Text = source.Text,
            NoteType = source.TypeValue,
            BaseType = source.BaseType,
            Type = source.Type
        };
    }

    public static List<Entity.OrderNote> ToEntities(IEnumerable<Payload.BTNote>? source, Entity.NoteKind kind)
    {
        return source?.Select(n => ToEntity(n, kind)).ToList() ?? [];
    }
}
