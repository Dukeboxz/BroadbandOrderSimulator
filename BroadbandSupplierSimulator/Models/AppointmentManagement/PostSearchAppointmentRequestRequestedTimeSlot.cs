using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentRequestRequestedTimeSlot
{
    [JsonPropertyName("validFor")]
    public required PostSearchAppointmentRequestRequestedTimeSlotValidFor ValidFor { get; set; }
}
