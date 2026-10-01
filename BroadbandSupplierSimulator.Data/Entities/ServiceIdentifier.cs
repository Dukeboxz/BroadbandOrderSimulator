using System.ComponentModel.DataAnnotations.Schema;

namespace BroadbandSupplierSimulator.Data.Entities;

[ComplexType]
public class ServiceIdentifier
{
    public string? Value { get; set; }
    public string? PreviousValue { get; set; }
}
