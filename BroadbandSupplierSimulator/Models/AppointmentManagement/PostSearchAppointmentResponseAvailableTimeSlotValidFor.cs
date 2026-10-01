using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentResponseAvailableTimeSlotValidFor
{
    [JsonPropertyName("startDateTime")]
    public required string StartDateTime { get; set; }

    [JsonPropertyName("endDateTime")]
    public required string EndDateTime { get; set; }
}
