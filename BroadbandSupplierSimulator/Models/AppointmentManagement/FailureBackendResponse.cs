using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class FailureBackendResponse
{
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    [JsonPropertyName("reason")]
    public required string Reason { get; set; }
}
