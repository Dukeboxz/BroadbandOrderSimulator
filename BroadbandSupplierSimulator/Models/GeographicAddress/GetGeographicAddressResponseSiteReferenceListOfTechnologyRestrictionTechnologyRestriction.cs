using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class GetGeographicAddressResponseSiteReferenceListOfTechnologyRestrictionTechnologyRestriction
{
    [JsonPropertyName("technologyRestrictionName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TechnologyRestrictionName { get; set; }

    [JsonPropertyName("technologyRestrictionValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TechnologyRestrictionValue { get; set; }
}
