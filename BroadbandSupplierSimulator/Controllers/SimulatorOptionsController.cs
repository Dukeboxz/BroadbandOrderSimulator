using BroadbandSupplierSimulator.Models.SimulatorOptions;
using BroadbandSupplierSimulator.Simulation;
using BroadbandSupplierSimulator.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("simulatorOptions")]
public class SimulatorOptionsController(
    ISetSimulationOptionsValidator validator,
    ISimulationOptionsUpdateHandler handler,
    IOptionsMonitor<SimulationOptions> options) : ControllerBase
{
    [HttpPost("SetOptions")]
    public IActionResult SetOptions([FromBody] SetSimulationOptionsRequest request)
    {
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            return BadRequest(new { errors = result.Errors });
        }

        handler.Apply(request);

        return Ok(options.CurrentValue);
    }
}
