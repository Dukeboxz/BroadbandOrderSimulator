using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace BroadbandSupplierSimulator.Simulation;

[AttributeUsage(AttributeTargets.Method)]
public sealed class SimulatedEndpointAttribute(string endpointName) : Attribute, IAsyncResourceFilter
{
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        var options = context.HttpContext.RequestServices.GetRequiredService<IOptionsMonitor<SimulationOptions>>().CurrentValue;

        if (options.Endpoints.TryGetValue(endpointName, out var settings))
        {
            if (settings.ResponseDelayMs > 0)
            {
                await Task.Delay(settings.ResponseDelayMs, context.HttpContext.RequestAborted);
            }

            if (settings.SendFailure)
            {
                context.Result = new ObjectResult(new { code = "01", message = "Internal Error" })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return;
            }
        }

        await next();
    }
}
