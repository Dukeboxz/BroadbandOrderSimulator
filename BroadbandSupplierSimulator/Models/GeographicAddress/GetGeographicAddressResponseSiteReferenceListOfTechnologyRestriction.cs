using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class GetGeographicAddressResponseSiteReferenceListOfTechnologyRestriction
{
    [JsonPropertyName("technologyRestriction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GetGeographicAddressResponseSiteReferenceListOfTechnologyRestrictionTechnologyRestriction>? TechnologyRestriction { get; set; }
}
