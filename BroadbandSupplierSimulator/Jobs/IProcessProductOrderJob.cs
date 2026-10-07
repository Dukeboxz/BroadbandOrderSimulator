namespace BroadbandSupplierSimulator.Jobs;

public interface IProcessProductOrderJob
{
    Task ProcessAsync(Guid productOrderId, CancellationToken cancellationToken);
}
