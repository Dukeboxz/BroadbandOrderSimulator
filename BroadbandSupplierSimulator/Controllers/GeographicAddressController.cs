using BroadbandSupplierSimulator.Models.GeographicAddress;
using BroadbandSupplierSimulator.Simulation;
using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("common/geographicAddressManagement/v1")]
public class GeographicAddressController : ControllerBase
{
    [HttpGet("geographicAddress")]
    [SimulatedEndpoint(nameof(GetGeographicAddress))]
    public IActionResult GetGeographicAddress(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "correlationId")] string? correlationId,
        [FromHeader(Name = "APIGW-Client-Id")] string? clientId,
        [FromHeader(Name = "btDuns")] string? btDuns,
        [FromQuery] string? postcode,
        [FromQuery] string? addressSource,
        [FromQuery] string? buildingName,
        [FromQuery] string? uprn,
        [FromQuery] string? streetNr,
        [FromQuery] string? subStreet,
        [FromQuery] string? locality,
        [FromQuery] string? subLocality,
        [FromQuery] string? subBuilding,
        [FromQuery] string? streetName,
        [FromQuery] string? city,
        [FromQuery] bool? isSpatialRefBng,
        [FromQuery] string? id,
        [FromQuery] bool? isSiteClassificationRequired,
        [FromQuery] bool? isTechonologyMarkersRequired,
        [FromQuery] bool? isFuzzyMatch,
        [FromQuery] string? searchType,
        [FromQuery] string? servicePointId,
        [FromQuery] string? country)
    {
        return Ok();
    }

    [HttpPost("geographicAddress")]
    [SimulatedEndpoint(nameof(CreateGeographicAddress))]
    public IActionResult CreateGeographicAddress(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "correlationId")] string? correlationId,
        [FromHeader(Name = "target")] string? target,
        [FromHeader(Name = "btDuns")] string? btDuns,
        [FromBody] CreateGeographicAddressRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }
}
