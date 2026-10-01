using BroadbandSupplierSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroadbandSupplierSimulator.Data.Configurations;

public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
{
    public void Configure(EntityTypeBuilder<ProductOrder> builder)
    {
        builder.Property(o => o.ExternalId).HasMaxLength(50);
        builder.HasIndex(o => o.ExternalId);
        builder.Property(o => o.ReceivedAt).HasDefaultValueSql("now()");
        builder.ComplexProperty(o => o.BillingAccount);
    }
}
