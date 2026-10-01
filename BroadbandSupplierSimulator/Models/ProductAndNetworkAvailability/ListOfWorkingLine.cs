using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class ListOfWorkingLine
{
    [JsonPropertyName("ServiceId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ServiceId { get; set; }

    [JsonPropertyName("AccessLineId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AccessLineId { get; set; }

    [JsonPropertyName("PartialDN")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PartialDN { get; set; }

    [JsonPropertyName("NumberRetentionAllowed")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NumberRetentionAllowed { get; set; }

    [JsonPropertyName("ProductType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ProductType { get; set; }

    [JsonPropertyName("PendingCeaseOrderIndicator")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PendingCeaseOrderIndicator { get; set; }

    [JsonPropertyName("PendingCeaseCompletionDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? PendingCeaseCompletionDate { get; set; }

    [JsonPropertyName("WorkingLineLocation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WorkingLineLocation { get; set; }

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
