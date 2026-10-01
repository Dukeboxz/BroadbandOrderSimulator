using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostAppointmentRequestRelatedEntityProduct
{
    [JsonPropertyName("productSpecification")]
    public required PostAppointmentRequestRelatedEntityProductProductSpecification ProductSpecification { get; set; }

    [JsonPropertyName("characteristic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PostAppointmentRequestRelatedEntityProductCharacteristic>? Characteristic { get; set; }

    [JsonPropertyName("place")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<PostAppointmentRequestRelatedEntityProductPlace>? Place { get; set; }
}
