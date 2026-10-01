using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.GeographicAddress;

public class GetGeographicAddressResponse
{
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    [JsonPropertyName("addressVerificationNeeded")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AddressVerificationNeeded { get; set; }

    [JsonPropertyName("uprn")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Uprn { get; set; }

    [JsonPropertyName("parentUPRN")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ParentUPRN { get; set; }

    [JsonPropertyName("addressSource")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AddressSource { get; set; }

    [JsonPropertyName("exchangeGroupCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExchangeGroupCode { get; set; }

    [JsonPropertyName("districtCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DistrictCode { get; set; }

    [JsonPropertyName("qualifier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Qualifier { get; set; }

    [JsonPropertyName("streetNr")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StreetNr { get; set; }

    [JsonPropertyName("streetName")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StreetName { get; set; }

    [JsonPropertyName("postcode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Postcode { get; set; }

    [JsonPropertyName("locality")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Locality { get; set; }

    [JsonPropertyName("city")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Country { get; set; }

    [JsonPropertyName("postalOrganisation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PostalOrganisation { get; set; }

    [JsonPropertyName("poBox")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PoBox { get; set; }

    [JsonPropertyName("county")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? County { get; set; }

    [JsonPropertyName("bestAddressLine1")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BestAddressLine1 { get; set; }

    [JsonPropertyName("bestAddressLine2")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BestAddressLine2 { get; set; }

    [JsonPropertyName("bestAddressLine3")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BestAddressLine3 { get; set; }

    [JsonPropertyName("bestAddressLine4")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BestAddressLine4 { get; set; }

    [JsonPropertyName("@type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }

    [JsonPropertyName("geographicLocationRefOrValue")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public JsonElement? GeographicLocationRefOrValue { get; set; }

    [JsonPropertyName("geographicSubAddress")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<GetGeographicAddressResponseGeographicSubAddress>? GeographicSubAddress { get; set; }

    [JsonPropertyName("siteReference")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GetGeographicAddressResponseSiteReference? SiteReference { get; set; }

    [JsonPropertyName("addressMatch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AddressMatch { get; set; }

    [JsonPropertyName("matchedId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MatchedId { get; set; }

    [JsonPropertyName("ListOfAdditionalAddressAttributes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public GetGeographicAddressResponseListOfAdditionalAddressAttributes? ListOfAdditionalAddressAttributes { get; set; }
}
