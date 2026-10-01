using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class BtONTResourceRefValuePORTLISTONTPORT
{
    [JsonPropertyName("ONTPORTNUMBER")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ONTPORTNUMBER { get; set; }

    [JsonPropertyName("ONTPORTSTATUS")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ONTPORTSTATUS { get; set; }

    [JsonPropertyName("ONTPORTTYPE")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ONTPORTTYPE { get; set; }

    [JsonPropertyName("VOICEWIRINGSTATUS")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? VOICEWIRINGSTATUS { get; set; }
}
