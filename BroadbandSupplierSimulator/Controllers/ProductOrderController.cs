using BroadbandSupplierSimulator.Models.ProductOrder;
using BroadbandSupplierSimulator.Services;
using BroadbandSupplierSimulator.Simulation;
using Microsoft.AspNetCore.Mvc;

namespace BroadbandSupplierSimulator.Controllers;

[ApiController]
[Route("hubco/tmf/productOrderingManagement/v4")]
public class ProductOrderController(ICreateProductOrderService createProductOrderService) : ControllerBase
{
    [HttpPost("productOrder")]
    [SimulatedEndpoint(nameof(CreateProductOrder))]
    public async Task<IActionResult> CreateProductOrder(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] ProductOrderCreate request,
        CancellationToken cancellationToken)
    {
        var result = await createProductOrderService.CreateProductOrder(request, cancellationToken);

        if (!result.IsValid)
        {
            return BadRequest(new BackendFailureResponse
            {
                Code = "23",
                Message = "Missing body field",
                Reason = string.Join(" ", result.Errors)
            });
        }

        return Accepted();
    }

    [HttpPost("productOrder/notification")]
    [SimulatedEndpoint(nameof(ProductOrderNotification))]
    public IActionResult ProductOrderNotification(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromHeader(Name = "apigw-client-id")] string clientId,
        [FromBody] ProductOrderCreateEvent request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPatch("productOrder/{id}")]
    [SimulatedEndpoint(nameof(AmendProductOrder))]
    public IActionResult AmendProductOrder(
        string id,
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] AmendProductOrderRequest request)
    {
        return Accepted();
    }

    [HttpPost("cancelProductOrder")]
    [SimulatedEndpoint(nameof(CancelProductOrder))]
    public IActionResult CancelProductOrder(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] CancelProductOrderCreateRequest request)
    {
        return Accepted();
    }

    [HttpPost("cancelProductOrder/notification")]
    [SimulatedEndpoint(nameof(CancelProductOrderNotification))]
    public IActionResult CancelProductOrderNotification(
        [FromHeader(Name = "APIGW-Tracking-Header")] string trackingHeader,
        [FromBody] CancelProductOrderNotificationRequest request)
    {
        return StatusCode(StatusCodes.Status201Created);
    }
}
