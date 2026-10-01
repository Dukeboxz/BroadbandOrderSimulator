using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class GetAddressLineAvailabilityResponseLineAvailability
{
    [JsonPropertyName("ExchangeGroupCode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ExchangeGroupCode { get; set; }

    [JsonPropertyName("MDFSiteId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MDFSiteId { get; set; }

    [JsonPropertyName("InstallationType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InstallationType { get; set; }

    [JsonPropertyName("ResultsTruncatedFlag")]
    public required string ResultsTruncatedFlag { get; set; }

    [JsonPropertyName("DesignDP")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? DesignDP { get; set; }

    [JsonPropertyName("DPSparePairs")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? DPSparePairs { get; set; }

    [JsonPropertyName("DPType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DPType { get; set; }

    [JsonPropertyName("StoppedLineQty")]
    public required int StoppedLineQty { get; set; }

    [JsonPropertyName("WorkingLineQty")]
    public required int WorkingLineQty { get; set; }

    [JsonPropertyName("RetentionOfCLIPossible")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? RetentionOfCLIPossible { get; set; }

    [JsonPropertyName("FTTPPriorityExchange")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FTTPPriorityExchange { get; set; }

    [JsonPropertyName("WLRWithdrawal")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? WLRWithdrawal { get; set; }

    [JsonPropertyName("MPFRestriction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MPFRestriction { get; set; }

    [JsonPropertyName("SOTAPRestriction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SOTAPRestriction { get; set; }

    [JsonPropertyName("ListOfStoppedLine")]
    public required List<ListOfStoppedLine> ListOfStoppedLine { get; set; }

    [JsonPropertyName("ListOfWorkingLine")]
    public required List<ListOfWorkingLine> ListOfWorkingLine { get; set; }
}
