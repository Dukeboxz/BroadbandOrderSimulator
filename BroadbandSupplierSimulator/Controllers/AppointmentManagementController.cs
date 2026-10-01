using System.ComponentModel.DataAnnotations;
using BroadbandSupplierSimulator.Models.AppointmentManagement;
using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("common/appointmentManagement/v4")]
public class AppointmentManagementController : ControllerBase
{
    [HttpPost("searchTimeSlot")]
    public IActionResult SearchTimeSlot(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "productFamily")][AllowedValues("Ethernet", "Broadband-One", "BB1Hub", "BBOne")] string productFamily,
        [FromBody] PostSearchAppointmentRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost("appointment")]
    public IActionResult CreateAppointment(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "productFamily")][AllowedValues("Ethernet", "Broadband-One", "BB1Hub", "BBOne")] string productFamily,
        [FromBody] PostAppointmentRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }
}
