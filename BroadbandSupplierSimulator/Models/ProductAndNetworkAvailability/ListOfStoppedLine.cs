using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class ListOfStoppedLine
{
    [JsonPropertyName("ServiceId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ServiceId { get; set; }

    [JsonPropertyName("AccessLineId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AccessLineId { get; set; }

    [JsonPropertyName("LastWorkingPartialDN")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LastWorkingPartialDN { get; set; }

    [JsonPropertyName("StoppedDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StoppedDate { get; set; }

    [JsonPropertyName("ProductType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ProductType { get; set; }

    [JsonPropertyName("StoppedLineLocation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StoppedLineLocation { get; set; }

    [JsonPropertyName("TechnologyType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TechnologyType { get; set; }

    [JsonPropertyName("TerminationType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? TerminationType { get; set; }

    [JsonPropertyName("NTEFaceplateTypeRecorded")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NTEFaceplateTypeRecorded { get; set; }

    [JsonPropertyName("NTETypeRecorded")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NTETypeRecorded { get; set; }

    [JsonPropertyName("NTELocationRecorded")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NTELocationRecorded { get; set; }

    [JsonPropertyName("DateNTEDetailsRecorded")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DateNTEDetailsRecorded { get; set; }

    [JsonPropertyName("InstallationType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InstallationType { get; set; }

    [JsonPropertyName("ExchangeGroupCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExchangeGroupCode { get; set; }

    [JsonPropertyName("CSSExchangeType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CSSExchangeType { get; set; }

    [JsonPropertyName("MDFSiteId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MDFSiteId { get; set; }
}
