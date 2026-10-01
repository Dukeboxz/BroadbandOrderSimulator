using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductAndNetworkAvailability;

public class BtONTResourceRefValuePORTLIST
{
    [JsonPropertyName("ONTPORT")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<BtONTResourceRefValuePORTLISTONTPORT>? ONTPORT { get; set; }
}
