using System.ComponentModel.DataAnnotations;
using System.Globalization;
using BroadbandSupplierSimulator.Models.AppointmentManagement;
using BroadbandSupplierSimulator.Services;
using BroadbandSupplierSimulator.Simulation;
using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("common/appointmentManagement/v4")]
public class AppointmentManagementController(IAppointmentService appointmentService) : ControllerBase
{
    [HttpPost("searchTimeSlot")]
    [SimulatedEndpoint(nameof(SearchTimeSlot))]
    public IActionResult SearchTimeSlot(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "productFamily")][AllowedValues("Ethernet", "Broadband-One", "BB1Hub", "BBOne")] string productFamily,
        [FromBody] PostSearchAppointmentRequest request)
    {
        if (request.RequestedTimeSlot.Count != 1)
        {
            ModelState.AddModelError(nameof(request.RequestedTimeSlot), "Exactly one requestedTimeSlot is accepted.");
            return ValidationProblem();
        }

        if (!DateTimeOffset.TryParse(request.RequestedTimeSlot[0].ValidFor.StartDateTime, CultureInfo.InvariantCulture, out _))
        {
            ModelState.AddModelError("requestedTimeSlot[0].validFor.startDateTime", "startDateTime is not a valid date and time.");
            return ValidationProblem();
        }

        return StatusCode(StatusCodes.Status201Created, appointmentService.GetSearchTimeSlotResponse(trackingHeader, productFamily, request));
    }

    [HttpPost("appointment")]
    [SimulatedEndpoint(nameof(CreateAppointment))]
    public IActionResult CreateAppointment(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "productFamily")][AllowedValues("Ethernet", "Broadband-One", "BB1Hub", "BBOne")] string productFamily,
        [FromBody] PostAppointmentRequest request)
    {
        return StatusCode(StatusCodes.Status201Created, appointmentService.GetCreateAppointmentResponse(trackingHeader, productFamily));
    }
}
