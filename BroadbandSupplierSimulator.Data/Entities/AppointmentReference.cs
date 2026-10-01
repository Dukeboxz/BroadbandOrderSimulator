using System.ComponentModel.DataAnnotations.Schema;

namespace BroadbandSupplierSimulator.Data.Entities;

[ComplexType]
public class AppointmentReference
{
    public required string AppointmentId { get; set; }
    public string? Description { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
    public required DateTimeOffset AppointmentStart { get; set; }
    public DateTimeOffset? AppointmentFinish { get; set; }
    public string? AppointmentStatus { get; set; }
    public required string BesAppointmentId { get; set; }
}
