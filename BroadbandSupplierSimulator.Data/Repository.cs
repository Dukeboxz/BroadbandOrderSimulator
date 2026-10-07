namespace BroadbandSupplierSimulator.Data;

public class Repository<T>(SimulatorDbContext context) : IRepository<T> where T : class
{
    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await context.Set<T>().AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}
