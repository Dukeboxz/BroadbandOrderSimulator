using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.AppointmentManagement;

public class PostAppointmentRequestRelatedEntity
{
    [JsonPropertyName("simProvide")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? SimProvide { get; set; }

    [JsonPropertyName("appointmentType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AppointmentType { get; set; }

    [JsonPropertyName("siteVisitReason")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SiteVisitReason { get; set; }

    [JsonPropertyName("newExchangeLine")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NewExchangeLine { get; set; }

    [JsonPropertyName("product")]
    public required PostAppointmentRequestRelatedEntityProduct Product { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("role")]
    public required string Role { get; set; }

    [JsonPropertyName("@referredType")]
    public required string ReferredType { get; set; }

    [JsonPropertyName("@type")]
    public required string Type { get; set; }

    [JsonPropertyName("@baseType")]
    public required string BaseType { get; set; }
}
