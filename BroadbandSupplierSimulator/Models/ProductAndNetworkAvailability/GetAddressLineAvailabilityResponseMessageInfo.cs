using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class GetAddressLineAvailabilityResponseMessageInfo
{
    [JsonPropertyName("CompletionCode")]
    public required int CompletionCode { get; set; }

    [JsonPropertyName("Message")]
    public required string Message { get; set; }

    [JsonPropertyName("Severity")]
    public required string Severity { get; set; }
}
