using BroadbandSupplierSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroadbandSupplierSimulator.Data.Configurations;

public class ProductOrderItemConfiguration : IEntityTypeConfiguration<ProductOrderItem>
{
    public void Configure(EntityTypeBuilder<ProductOrderItem> builder)
    {
        builder.Property(i => i.Action).HasConversion<string>();
        builder.Property(i => i.State).HasConversion<string>();
        builder.Property(i => i.AmendmentStatus).HasConversion<string>();
        builder.Property(i => i.CancellationStatus).HasConversion<string>();

        builder.HasIndex(i => new { i.ProductOrderId, i.ItemId }).IsUnique();

        builder.HasOne(i => i.ParentItem).WithMany(i => i.ChildItems).HasForeignKey(i => i.ParentItemId);
        builder.HasOne(i => i.Product).WithOne(p => p.ProductOrderItem).HasForeignKey<OrderProduct>(p => p.ProductOrderItemId);

        builder.ComplexProperty(i => i.BillingAccount);
        builder.ComplexProperty(i => i.ProductOffering);
        builder.ComplexProperty(i => i.Appointment);
        builder.ComplexProperty(i => i.ProductOfferingQualificationItem);
    }
}
