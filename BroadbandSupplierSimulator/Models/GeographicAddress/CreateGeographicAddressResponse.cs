using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class CreateGeographicAddressResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
}
