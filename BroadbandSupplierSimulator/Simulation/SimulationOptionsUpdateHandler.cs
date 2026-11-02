using BroadbandSupplierSimulator.Models.SimulatorOptions;
using Microsoft.Extensions.Options;

namespace BroadbandSupplierSimulator.Simulation;

/// <summary>
/// Keeps every applied update and replays them, in order, whenever <see cref="SimulationOptions"/> are built,
/// so updates survive a configuration reload. Applying an update clears the options cache so
/// <see cref="IOptionsMonitor{TOptions}.CurrentValue"/> picks it up straight away.
/// </summary>
public class SimulationOptionsUpdateHandler(IOptionsMonitorCache<SimulationOptions> cache)
    : ISimulationOptionsUpdateHandler, IPostConfigureOptions<SimulationOptions>
{
    private readonly List<SetSimulationOptionsRequest> updates = [];
    private readonly Lock updatesLock = new();

    public void Apply(SetSimulationOptionsRequest request)
    {
        lock (updatesLock)
        {
            updates.Add(request);
        }

        cache.TryRemove(Options.DefaultName);
    }

    public void PostConfigure(string? name, SimulationOptions target)
    {
        if (name != Options.DefaultName)
        {
            return;
        }

        lock (updatesLock)
        {
            foreach (var update in updates)
            {
                ApplyTo(update, target);
            }
        }
    }

    internal static void ApplyTo(SetSimulationOptionsRequest request, SimulationOptions target)
    {
        if (request.StageReturnFailure is not null)
        {
            target.StageReturnFailure = request.StageReturnFailure;
        }

        if (request.MessageGapMs is { } messageGapMs)
        {
            target.MessageGapMs = messageGapMs;
        }

        if (request.SendUrl is not null)
        {
            target.SendUrl = request.SendUrl;
        }

        if (request.MessageOrder is not null)
        {
            target.MessageOrder = request.MessageOrder.Count == 0
                ? null
                : request.MessageOrder.Select(s => new MessageStage
                {
                    SequenceOrder = s.SequenceOrder!.Value,
                    State = s.State!.Value,
                    SubStatus = s.SubStatus
                }).ToList();
        }

        foreach (var (name, update) in request.Endpoints ?? [])
        {
            var canonicalName = SimulatedEndpoints.Names.TryGetValue(name, out var known) ? known : name;

            if (!target.Endpoints.TryGetValue(canonicalName, out var settings))
            {
                settings = new EndpointSimulationSettings();
                target.Endpoints[canonicalName] = settings;
            }

            if (update.SendFailure is { } sendFailure)
            {
                settings.SendFailure = sendFailure;
            }

            if (update.ResponseDelayMs is { } responseDelayMs)
            {
                settings.ResponseDelayMs = responseDelayMs;
            }

            if (update.AppointmentAvailable is { } appointmentAvailable)
            {
                settings.AppointmentAvailable = appointmentAvailable;
            }
        }
    }
}
