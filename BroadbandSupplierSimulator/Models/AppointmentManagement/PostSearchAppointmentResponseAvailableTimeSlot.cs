using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentResponseAvailableTimeSlot
{
    [JsonPropertyName("slot")]
    public required string Slot { get; set; }

    [JsonPropertyName("validFor")]
    public required PostSearchAppointmentResponseAvailableTimeSlotValidFor ValidFor { get; set; }
}
