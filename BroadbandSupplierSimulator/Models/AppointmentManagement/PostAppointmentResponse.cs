using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostAppointmentResponse
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("creationDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CreationDate { get; set; }

    [JsonPropertyName("relatedEntity")]
    public required List<PostAppointmentResponseRelatedEntity> RelatedEntity { get; set; }

    [JsonPropertyName("validFor")]
    public required PostAppointmentResponseValidFor ValidFor { get; set; }
}
