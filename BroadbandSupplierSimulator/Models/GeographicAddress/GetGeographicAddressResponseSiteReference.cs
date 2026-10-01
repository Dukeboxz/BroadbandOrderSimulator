using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class GetGeographicAddressResponseSiteReference
{
    [JsonPropertyName("siteClassificationCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SiteClassificationCode { get; set; }

    [JsonPropertyName("siteClassification")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SiteClassification { get; set; }

    [JsonPropertyName("listOfTechnology")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GetGeographicAddressResponseSiteReferenceListOfTechnology? ListOfTechnology { get; set; }

    [JsonPropertyName("listOfTechnologyRestriction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GetGeographicAddressResponseSiteReferenceListOfTechnologyRestriction? ListOfTechnologyRestriction { get; set; }
}
