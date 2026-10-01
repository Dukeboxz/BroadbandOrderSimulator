using BroadbandSupplierSimulator.Models.AppointmentManagement;

namespace BroadbandSupplierSimulator.Services;

public interface IAppointmentService
{
    PostSearchAppointmentResponse GetSearchTimeSlotResponse(string trackingHeader, string productFamily, PostSearchAppointmentRequest request);

    PostAppointmentResponse GetCreateAppointmentResponse(string trackingHeader, string productFamily);
}
