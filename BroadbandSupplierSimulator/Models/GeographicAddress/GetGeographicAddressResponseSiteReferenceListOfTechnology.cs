using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class GetGeographicAddressResponseSiteReferenceListOfTechnology
{
    [JsonPropertyName("technology")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GetGeographicAddressResponseSiteReferenceListOfTechnologyTechnology>? Technology { get; set; }
}
