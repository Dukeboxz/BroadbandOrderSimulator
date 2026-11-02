using BroadbandSupplierSimulator.Data.Entities;
using BroadbandSupplierSimulator.Models.SimulatorOptions;
using BroadbandSupplierSimulator.Simulation;

namespace BroadbandSupplierSimulator.Validation;

public class SetSimulationOptionsValidator : ISetSimulationOptionsValidator
{
    public OrderValidationResult Validate(SetSimulationOptionsRequest request)
    {
        var result = new OrderValidationResult();

        if (request.StageReturnFailure is { } stage && !string.IsNullOrWhiteSpace(stage) && !IsKnownStage(stage))
        {
            result.AddError($"StageReturnFailure '{stage}' is not a known state or sub status.");
        }

        if (request.MessageGapMs < 0)
        {
            result.AddError("MessageGapMs must be 0 or greater.");
        }

        if (!string.IsNullOrEmpty(request.SendUrl) && !IsHttpUrl(request.SendUrl))
        {
            result.AddError("SendUrl must be an absolute http or https URL, or empty to disable sending.");
        }

        if (request.MessageOrder is not null)
        {
            ValidateMessageOrder(request.MessageOrder, result);
        }

        if (request.Endpoints is not null)
        {
            ValidateEndpoints(request.Endpoints, result);
        }

        return result;
    }

    private static void ValidateMessageOrder(List<SetMessageStageRequest> messageOrder, OrderValidationResult result)
    {
        for (var i = 0; i < messageOrder.Count; i++)
        {
            var stage = messageOrder[i];

            if (stage is null)
            {
                result.AddError($"MessageOrder[{i}] must not be null.");
                continue;
            }

            if (stage.SequenceOrder is null)
            {
                result.AddError($"MessageOrder[{i}].SequenceOrder is required.");
            }

            if (stage.State is null)
            {
                result.AddError($"MessageOrder[{i}].State is required.");
            }
            else if (!Enum.IsDefined(stage.State.Value))
            {
                result.AddError($"MessageOrder[{i}].State '{stage.State}' is not a valid state.");
            }

            if (stage.SubStatus is { } subStatus && !Enum.IsDefined(subStatus))
            {
                result.AddError($"MessageOrder[{i}].SubStatus '{stage.SubStatus}' is not a valid sub status.");
            }
        }

        var duplicates = messageOrder
            .Where(s => s?.SequenceOrder is not null)
            .GroupBy(s => s.SequenceOrder!.Value)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);

        foreach (var sequenceOrder in duplicates)
        {
            result.AddError($"MessageOrder SequenceOrder {sequenceOrder} is used more than once.");
        }
    }

    private static void ValidateEndpoints(Dictionary<string, SetEndpointSimulationSettingsRequest> endpoints, OrderValidationResult result)
    {
        foreach (var (name, settings) in endpoints)
        {
            if (!SimulatedEndpoints.Names.Contains(name))
            {
                result.AddError($"Endpoint '{name}' is not a known endpoint.");
                continue;
            }

            if (settings is null)
            {
                result.AddError($"Endpoints.{name} must not be null.");
                continue;
            }

            if (settings.ResponseDelayMs < 0)
            {
                result.AddError($"Endpoints.{name}.ResponseDelayMs must be 0 or greater.");
            }

            if (settings.AppointmentAvailable is not null
                && !string.Equals(name, SimulatedEndpoints.SearchTimeSlot, StringComparison.OrdinalIgnoreCase))
            {
                result.AddError($"Endpoints.{name}.AppointmentAvailable is only supported for {SimulatedEndpoints.SearchTimeSlot}.");
            }
        }
    }

    private static bool IsKnownStage(string stage)
    {
        return TryParseEnum<ProductOrderItemState>(stage, out _)
            || TryParseEnum<MessageSubStatus>(stage, out _)
            || Enum.GetValues<MessageSubStatus>().Any(s => string.Equals(s.ToValue(), stage, StringComparison.OrdinalIgnoreCase));
    }

    private static bool IsHttpUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uri)
            && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }

    /// <summary>Parses an enum by name only (case-insensitive), rejecting numeric values.</summary>
    private static bool TryParseEnum<TEnum>(string value, out TEnum parsed) where TEnum : struct, Enum
    {
        parsed = default;
        return !int.TryParse(value, out _)
            && Enum.TryParse(value.Trim(), ignoreCase: true, out parsed)
            && Enum.IsDefined(parsed);
    }
}
