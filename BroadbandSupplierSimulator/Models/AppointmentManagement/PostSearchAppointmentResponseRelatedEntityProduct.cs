using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentResponseRelatedEntityProduct
{
    [JsonPropertyName("productSpecification")]
    public required PostSearchAppointmentResponseRelatedEntityProductProductSpecification ProductSpecification { get; set; }

    [JsonPropertyName("characteristic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PostSearchAppointmentResponseRelatedEntityProductCharacteristic>? Characteristic { get; set; }

    [JsonPropertyName("place")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PostSearchAppointmentResponseRelatedEntityProductPlace>? Place { get; set; }
}
