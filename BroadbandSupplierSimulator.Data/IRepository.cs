namespace BroadbandSupplierSimulator.Data;

public interface IRepository<T> where T : class
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
}
