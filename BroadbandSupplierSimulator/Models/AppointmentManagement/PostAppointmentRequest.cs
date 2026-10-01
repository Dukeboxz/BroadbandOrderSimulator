using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostAppointmentRequest
{
    [JsonPropertyName("relatedEntity")]
    public required List<PostAppointmentRequestRelatedEntity> RelatedEntity { get; set; }

    [JsonPropertyName("validFor")]
    public required PostAppointmentRequestValidFor ValidFor { get; set; }
}
