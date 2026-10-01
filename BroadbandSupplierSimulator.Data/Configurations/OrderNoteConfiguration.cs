using BroadbandSupplierSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BroadbandSupplierSimulator.Data.Configurations;

public class OrderNoteConfiguration : IEntityTypeConfiguration<OrderNote>
{
    public void Configure(EntityTypeBuilder<OrderNote> builder)
    {
        builder.Property(n => n.Kind).HasConversion<string>();
        builder.Property(n => n.Text).HasMaxLength(3999);
    }
}
