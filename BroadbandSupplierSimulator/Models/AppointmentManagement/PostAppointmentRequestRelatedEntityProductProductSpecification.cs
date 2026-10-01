using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostAppointmentRequestRelatedEntityProductProductSpecification
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }
}
