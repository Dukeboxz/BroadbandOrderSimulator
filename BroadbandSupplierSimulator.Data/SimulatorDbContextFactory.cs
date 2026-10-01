using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BroadbandSupplierSimulator.Data;

public class SimulatorDbContextFactory : IDesignTimeDbContextFactory<SimulatorDbContext>
{
    private const string ConnectionStringVariable = "ConnectionStrings__Hobby";
    private const string DefaultConnectionString = "Host=localhost;Port=5432;Database=hobby;Username=postgres;Password=devpass";

    public SimulatorDbContext CreateDbContext(string[] args)
    {
        var connectionString = Environment.GetEnvironmentVariable(ConnectionStringVariable) ?? DefaultConnectionString;
        var options = new DbContextOptionsBuilder<SimulatorDbContext>().UseNpgsql(connectionString).Options;

        return new SimulatorDbContext(options);
    }
}
