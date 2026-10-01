using BroadbandSupplierSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroadbandSupplierSimulator.Data.Configurations;

public class OrderPlaceConfiguration : IEntityTypeConfiguration<OrderPlace>
{
    public void Configure(EntityTypeBuilder<OrderPlace> builder)
    {
        builder.ComplexProperty(p => p.Address);
    }
}
