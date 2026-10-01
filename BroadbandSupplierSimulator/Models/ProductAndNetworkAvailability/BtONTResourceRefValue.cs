using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class BtONTResourceRefValue
{
    [JsonPropertyName("ONTSERIALNUMBER")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ONTSERIALNUMBER { get; set; }

    [JsonPropertyName("ONTREFNUMBER")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ONTREFNUMBER { get; set; }

    [JsonPropertyName("ONTFLOOR")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ONTFLOOR { get; set; }

    [JsonPropertyName("ONTROOM")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ONTROOM { get; set; }

    [JsonPropertyName("ONTPOSITION")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ONTPOSITION { get; set; }

    [JsonPropertyName("BBUSTATUS")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BBUSTATUS { get; set; }

    [JsonPropertyName("MAXSPEED")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? MAXSPEED { get; set; }

    [JsonPropertyName("PORTLIST")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BtONTResourceRefValuePORTLIST? PORTLIST { get; set; }
}
