using BroadbandSupplierSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroadbandSupplierSimulator.Data.Configurations;

public class ProductRelationshipConfiguration : IEntityTypeConfiguration<ProductRelationship>
{
    public void Configure(EntityTypeBuilder<ProductRelationship> builder)
    {
        builder.HasOne(r => r.OrderProduct).WithMany(p => p.Relationships).HasForeignKey(r => r.OrderProductId);
        builder.HasOne(r => r.Product).WithOne(p => p.ProductRelationship).HasForeignKey<OrderProduct>(p => p.ProductRelationshipId);
    }
}
