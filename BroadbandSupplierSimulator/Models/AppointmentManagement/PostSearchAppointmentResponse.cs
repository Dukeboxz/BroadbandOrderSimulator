using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("searchDate")]
    public required string SearchDate { get; set; }

    [JsonPropertyName("relatedEntity")]
    public required List<PostSearchAppointmentResponseRelatedEntity> RelatedEntity { get; set; }

    [JsonPropertyName("requestedTimeSlot")]
    public required List<PostSearchAppointmentResponseRequestedTimeSlot> RequestedTimeSlot { get; set; }

    [JsonPropertyName("availableTimeSlot")]
    public required List<PostSearchAppointmentResponseAvailableTimeSlot> AvailableTimeSlot { get; set; }
}
