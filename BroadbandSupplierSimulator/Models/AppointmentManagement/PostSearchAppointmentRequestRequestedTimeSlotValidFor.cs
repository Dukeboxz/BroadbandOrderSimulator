using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentRequestRequestedTimeSlotValidFor
{
    [JsonPropertyName("startDateTime")]
    public required string StartDateTime { get; set; }
}
