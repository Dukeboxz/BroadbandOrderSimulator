using System.ComponentModel.DataAnnotations.Schema;

namespace BroadbandSupplierSimulator.Data.Entities;

[ComplexType]
public class BillingAccountReference
{
    public required string AccountId { get; set; }
    public string? BaseType { get; set; }
    public string? Type { get; set; }
}
