using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BroadbandSupplierSimulator.Simulation;

[AttributeUsage(AttributeTargets.Method)]
public sealed class SimulatedEndpointAttribute(string endpointName) : Attribute, IAsyncResourceFilter
{
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        var helper = context.HttpContext.RequestServices.GetRequiredService<ISimulationHelper>();

        await helper.DelayResponseAsync(endpointName, context.HttpContext.RequestAborted);

        if (helper.GetSettings(endpointName).SendFailure)
        {
            context.Result = new ObjectResult(new { code = "01", message = "Internal Error" })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            return;
        }

        await next();
    }
}
