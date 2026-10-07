using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BroadbandSupplierSimulator.Data;

public class SimulatorDbContextFactory : IDesignTimeDbContextFactory<SimulatorDbContext>
{
    private const string ConnectionStringName = "Hobby";

    public SimulatorDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<SimulatorDbContextFactory>(optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString(ConnectionStringName)
            ?? throw new InvalidOperationException($"Connection string '{ConnectionStringName}' is not configured. Set it with: dotnet user-secrets set \"ConnectionStrings:{ConnectionStringName}\" \"<value>\" --project BroadbandSupplierSimulator");

        var options = new DbContextOptionsBuilder<SimulatorDbContext>().UseNpgsql(connectionString).Options;

        return new SimulatorDbContext(options);
    }
}
