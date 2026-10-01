using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BroadbandSupplierSimulator.Data;

public static class DataServiceCollectionExtensions
{
    public static IServiceCollection AddSimulatorData(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<SimulatorDbContext>(options => options.UseNpgsql(connectionString));
    }
}
