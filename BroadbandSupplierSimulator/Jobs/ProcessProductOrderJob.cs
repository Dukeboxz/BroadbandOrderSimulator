using System.Net.Http.Json;
using BroadbandSupplierSimulator.Data;
using BroadbandSupplierSimulator.Data.Entities;
using BroadbandSupplierSimulator.Mappers;
using BroadbandSupplierSimulator.Simulation;
using Hangfire;
using Microsoft.Extensions.Options;

namespace BroadbandSupplierSimulator.Jobs;

public class ProcessProductOrderJob(
    ILogger<ProcessProductOrderJob> logger,
    IRepository<ProductOrder> repository,
    IBackgroundJobClient backgroundJobClient,
    IHttpClientFactory httpClientFactory,
    IOptionsMonitor<SimulationOptions> options) : IProcessProductOrderJob
{
    private static readonly ProductOrderItemState[] TerminalStates =
    [
        ProductOrderItemState.Completed,
        ProductOrderItemState.Rejected,
        ProductOrderItemState.Failed,
        ProductOrderItemState.Cancelled
    ];

    private static readonly string[] InProgressSubStatuses =
    [
        "AcceptedByBTWwBC",
        "AwaitingECCConfirmation",
        "CommittedByBTWwBC",
        "CompletedBTWwBCService"
    ];

    public async Task ProcessAsync(Guid productOrderId, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing product order {ProductOrderId}", productOrderId);

        var productOrder = await repository.GetAsync(o => o.Id == productOrderId, cancellationToken, o => o.Items);

        if (productOrder is null)
        {
            logger.LogWarning("Product order {ProductOrderId} not found", productOrderId);
            return;
        }

        if (AllTerminal(productOrder))
        {
            logger.LogInformation("Product order {ProductOrderId} items are all in a terminal state", productOrderId);
            return;
        }

        var failureStage = options.CurrentValue.StageReturnFailure;

        foreach (var item in productOrder.Items.Where(i => !IsTerminal(i)))
        {
            Advance(item, options.CurrentValue.MessageOrder);

            if (MatchesStage(item, failureStage))
            {
                item.State = ProductOrderItemState.Failed;
            }
        }

        await repository.UpdateAsync(productOrder, cancellationToken);

        await SendAsync(productOrder, cancellationToken);

        if (AllTerminal(productOrder))
        {
            return;
        }

        var gap = TimeSpan.FromMilliseconds(Math.Max(0, options.CurrentValue.MessageGapMs));
        backgroundJobClient.Schedule<IProcessProductOrderJob>(job => job.ProcessAsync(productOrderId, CancellationToken.None), gap);
    }

    private async Task SendAsync(ProductOrder productOrder, CancellationToken cancellationToken)
    {
        var sendUrl = options.CurrentValue.SendUrl;

        if (string.IsNullOrWhiteSpace(sendUrl))
        {
            logger.LogWarning("SendUrl is not configured; skipping message for product order {ProductOrderId}", productOrder.Id);
            return;
        }

        var productOrderEvent = ProductOrderEventMapper.ToEvent(productOrder);
        var client = httpClientFactory.CreateClient();
        using var response = await client.PostAsJsonAsync(sendUrl, productOrderEvent, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    private static bool IsTerminal(ProductOrderItem item) => item.State is { } state && TerminalStates.Contains(state);

    private static bool AllTerminal(ProductOrder productOrder) => productOrder.Items.All(IsTerminal);

    private static bool MatchesStage(ProductOrderItem item, string stage)
    {
        if (string.IsNullOrWhiteSpace(stage))
        {
            return false;
        }

        return string.Equals(item.State?.ToString(), stage, StringComparison.OrdinalIgnoreCase)
            || string.Equals(item.SubStatus, stage, StringComparison.OrdinalIgnoreCase);
    }

    private void Advance(ProductOrderItem item, List<MessageStage>? messageOrder)
    {
        if (messageOrder is not null)
        {
            AdvanceThroughMessageOrder(item, messageOrder);
            return;
        }

        switch (item.State)
        {
            case null:
                item.State = ProductOrderItemState.Acknowledged;
                break;
            case ProductOrderItemState.Acknowledged:
                item.State = ProductOrderItemState.InProgress;
                item.SubStatus = InProgressSubStatuses[0];
                break;
            case ProductOrderItemState.InProgress:
                var index = Array.IndexOf(InProgressSubStatuses, item.SubStatus);
                if (index >= 0 && index < InProgressSubStatuses.Length - 1)
                {
                    item.SubStatus = InProgressSubStatuses[index + 1];
                }
                else
                {
                    item.State = ProductOrderItemState.Completed;
                }

                break;
            default:
                item.State = ProductOrderItemState.Completed;
                break;
        }
    }

    private void AdvanceThroughMessageOrder(ProductOrderItem item, List<MessageStage> messageOrder)
    {
        var ordered = messageOrder.OrderBy(s => s.SequenceOrder).ToList();
        MessageStage? next;

        if (item.State is null)
        {
            next = ordered.FirstOrDefault();
        }
        else
        {
            var current = ordered.FirstOrDefault(s => s.State == item.State
                && string.Equals(NullIfEmpty(s.SubStatus?.ToValue()), NullIfEmpty(item.SubStatus), StringComparison.OrdinalIgnoreCase));

            if (current is null)
            {
                logger.LogWarning("Item {ItemId} in state {State}/{SubStatus} is not in MessageOrder; moving to Completed", item.ItemId, item.State, item.SubStatus);
            }

            next = current is null ? null : ordered.FirstOrDefault(s => s.SequenceOrder > current.SequenceOrder);
        }

        if (next is null)
        {
            item.State = ProductOrderItemState.Completed;
            return;
        }

        item.State = next.State;
        item.SubStatus = next.SubStatus?.ToValue();
    }

    private static string? NullIfEmpty(string? value) => string.IsNullOrEmpty(value) ? null : value;
}
