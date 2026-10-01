using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentRequest
{
    [JsonPropertyName("relatedEntity")]
    public required List<PostSearchAppointmentRequestRelatedEntity> RelatedEntity { get; set; }

    [JsonPropertyName("requestedTimeSlot")]
    public required List<PostSearchAppointmentRequestRequestedTimeSlot> RequestedTimeSlot { get; set; }
}
