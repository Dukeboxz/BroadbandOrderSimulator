using BroadbandSupplierSimulator.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BroadbandSupplierSimulator.Data;

public class SimulatorDbContext(DbContextOptions<SimulatorDbContext> options) : DbContext(options)
{
    public DbSet<ProductOrder> ProductOrders => Set<ProductOrder>();

    public DbSet<ProductOrderItem> ProductOrderItems => Set<ProductOrderItem>();

    public DbSet<OrderNote> OrderNotes => Set<OrderNote>();

    public DbSet<OrderRelatedParty> OrderRelatedParties => Set<OrderRelatedParty>();

    public DbSet<OrderContactMedium> OrderContactMedia => Set<OrderContactMedium>();

    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();

    public DbSet<OrderPlace> OrderPlaces => Set<OrderPlace>();

    public DbSet<OrderCharacteristic> OrderCharacteristics => Set<OrderCharacteristic>();

    public DbSet<ProductRelationship> ProductRelationships => Set<ProductRelationship>();

    public DbSet<OrderItemRelationship> OrderItemRelationships => Set<OrderItemRelationship>();

    public DbSet<OrderQualification> OrderQualifications => Set<OrderQualification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SimulatorDbContext).Assembly);

        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }
}
