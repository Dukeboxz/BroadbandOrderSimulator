using System.Reflection;

namespace BroadbandSupplierSimulator.Simulation;

public static class SimulatedEndpoints
{
    public const string SearchTimeSlot = "SearchTimeSlot";

    /// <summary>Every endpoint name used by a <see cref="SimulatedEndpointAttribute"/> in this assembly.</summary>
    public static HashSet<string> Names { get; } = typeof(SimulatedEndpointAttribute).Assembly
        .GetTypes()
        .SelectMany(t => t.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        .SelectMany(m => m.GetCustomAttributes<SimulatedEndpointAttribute>())
        .Select(a => a.EndpointName)
        .ToHashSet(StringComparer.OrdinalIgnoreCase);
}
