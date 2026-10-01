using System.ComponentModel.DataAnnotations;
using BroadbandSupplierSimulator.Models.AppointmentManagement;
using BroadbandSupplierSimulator.Simulation;
using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("common/appointmentManagement/v4")]
public class AppointmentManagementController : ControllerBase
{
    [HttpPost("searchTimeSlot")]
    [SimulatedEndpoint(nameof(SearchTimeSlot))]
    public IActionResult SearchTimeSlot(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "productFamily")][AllowedValues("Ethernet", "Broadband-One", "BB1Hub", "BBOne")] string productFamily,
        [FromBody] PostSearchAppointmentRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost("appointment")]
    [SimulatedEndpoint(nameof(CreateAppointment))]
    public IActionResult CreateAppointment(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "productFamily")][AllowedValues("Ethernet", "Broadband-One", "BB1Hub", "BBOne")] string productFamily,
        [FromBody] PostAppointmentRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }
}
