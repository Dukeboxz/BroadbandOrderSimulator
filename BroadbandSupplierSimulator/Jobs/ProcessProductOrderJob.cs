namespace BroadbandSupplierSimulator.Jobs;

public class ProcessProductOrderJob(ILogger<ProcessProductOrderJob> logger) : IProcessProductOrderJob
{
    public Task ProcessAsync(Guid productOrderId, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing product order {ProductOrderId}", productOrderId);

        return Task.CompletedTask;
    }
}
