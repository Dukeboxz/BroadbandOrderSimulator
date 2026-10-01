using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("tmf/productInventory/v4")]
public class ProductInventoryController : ControllerBase
{
    [HttpGet("product")]
    public IActionResult GetProduct(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "Accept")] string accept,
        [FromHeader(Name = "source")] string? source,
        [FromHeader(Name = "btCug")] string? btCug,
        [FromQuery] string? serviceId)
    {
        return Ok();
    }
}
