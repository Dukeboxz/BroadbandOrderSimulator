using BroadbandSupplierSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroadbandSupplierSimulator.Data.Configurations;

public class OrderCharacteristicConfiguration : IEntityTypeConfiguration<OrderCharacteristic>
{
    public void Configure(EntityTypeBuilder<OrderCharacteristic> builder)
    {
        builder.Property(c => c.Action).HasConversion<string>();
    }
}
