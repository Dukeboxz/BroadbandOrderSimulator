using BroadbandSupplierSimulator.Models.ProductOrder;
using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("hubco/tmf/productOrderingManagement/v4")]
public class ProductOrderController : ControllerBase
{
    [HttpPost("productOrder")]
    public IActionResult CreateProductOrder(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] ProductOrderCreate request)
    {
        return Accepted();
    }

    [HttpPost("productOrder/notification")]
    public IActionResult ProductOrderNotification(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "apigw-client-id")] string clientId,
        [FromBody] ProductOrderCreateEvent request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPatch("productOrder/{id}")]
    public IActionResult AmendProductOrder(
        string id,
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] AmendProductOrderRequest2 request)
    {
        return Accepted();
    }

    [HttpPost("cancelProductOrder")]
    public IActionResult CancelProductOrder(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] CancelProductOrderCreateRequest request)
    {
        return Accepted();
    }

    [HttpPost("cancelProductOrder/notification")]
    public IActionResult CancelProductOrderNotification(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] CancelProductOrderNotificationRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }
}
