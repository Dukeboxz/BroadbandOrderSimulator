using BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;
using BroadbandSupplierSimulator.Simulation;
using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
public class ProductAndNetworkAvailabilityController : ControllerBase
{
    [HttpPost("hubco/tmf/productOfferingQualification/v4/productOfferingQualification")]
    [SimulatedEndpoint(nameof(CreateProductOfferingQualification))]
    public IActionResult CreateProductOfferingQualification(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] ProductOfferingQualificationCreate request)
    {
        return Ok();
    }

    [HttpGet("v1/line-availability/line")]
    [SimulatedEndpoint(nameof(GetAddressLineAvailability))]
    public IActionResult GetAddressLineAvailability(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "Authorization")] string authorization,
        [FromHeader(Name = "Destination-System")] string destinationSystem,
        [FromQuery(Name = "DUNSID")] string? dunsId,
        [FromQuery] string? districtCode,
        [FromQuery(Name = "NAD")] string? nad,
        [FromQuery] string? installationDN,
        [FromQuery] string? retentionCLI)
    {
        return Ok();
    }
}
