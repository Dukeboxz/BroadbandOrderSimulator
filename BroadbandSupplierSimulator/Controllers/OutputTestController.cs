using System.Text.Json;
using BroadbandSupplierSimulator.Models.ProductOrder;
using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("outputTest")]
public class OutputTestController(ILogger<OutputTestController> logger) : ControllerBase
{
    private static readonly JsonSerializerOptions IndentedOptions = new() { WriteIndented = true };

    [HttpPost]
    public IActionResult Post([FromBody] ProductOrderCreateEvent request)
    {
        logger.LogInformation("outputTest received product order event:{NewLine}{Json}",
            Environment.NewLine,
            JsonSerializer.Serialize(request, IndentedOptions));

        return Ok();
    }
}
