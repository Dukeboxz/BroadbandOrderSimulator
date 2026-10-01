using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class GetAddressLineAvailabilityResponse
{
    [JsonPropertyName("LineAvailability")]
    public required GetAddressLineAvailabilityResponseLineAvailability LineAvailability { get; set; }

    [JsonPropertyName("MessageInfo")]
    public required List<GetAddressLineAvailabilityResponseMessageInfo> MessageInfo { get; set; }
}
