using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostSearchAppointmentRequestRelatedEntityProduct
{
    [JsonPropertyName("productSpecification")]
    public required PostSearchAppointmentRequestRelatedEntityProductProductSpecification ProductSpecification { get; set; }

    [JsonPropertyName("characteristic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PostSearchAppointmentRequestRelatedEntityProductCharacteristic>? Characteristic { get; set; }

    [JsonPropertyName("place")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PostSearchAppointmentRequestRelatedEntityProductPlace>? Place { get; set; }
}
