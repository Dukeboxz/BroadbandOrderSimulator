using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostAppointmentResponseRelatedEntityProduct
{
    [JsonPropertyName("productSpecification")]
    public required PostAppointmentResponseRelatedEntityProductProductSpecification ProductSpecification { get; set; }

    [JsonPropertyName("characteristic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PostAppointmentResponseRelatedEntityProductCharacteristic>? Characteristic { get; set; }

    [JsonPropertyName("place")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PostAppointmentResponseRelatedEntityProductPlace>? Place { get; set; }
}
