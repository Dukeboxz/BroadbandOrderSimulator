using BroadbandSupplierSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroadbandSupplierSimulator.Data.Configurations;

public class OrderContactMediumConfiguration : IEntityTypeConfiguration<OrderContactMedium>
{
    public void Configure(EntityTypeBuilder<OrderContactMedium> builder)
    {
        builder.ComplexProperty(m => m.Address);
    }
}
