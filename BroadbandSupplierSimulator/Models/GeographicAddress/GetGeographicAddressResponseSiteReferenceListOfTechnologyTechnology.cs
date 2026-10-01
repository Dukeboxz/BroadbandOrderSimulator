using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class GetGeographicAddressResponseSiteReferenceListOfTechnologyTechnology
{
    [JsonPropertyName("technologyName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TechnologyName { get; set; }

    [JsonPropertyName("technologyValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TechnologyValue { get; set; }
}
