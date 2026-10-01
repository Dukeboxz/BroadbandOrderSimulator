using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentResponseRequestedTimeSlot
{
    [JsonPropertyName("validFor")]
    public required PostSearchAppointmentResponseRequestedTimeSlotValidFor ValidFor { get; set; }
}
