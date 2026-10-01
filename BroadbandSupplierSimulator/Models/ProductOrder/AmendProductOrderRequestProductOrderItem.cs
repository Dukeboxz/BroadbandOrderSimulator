using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class AmendProductOrderRequestProductOrderItem
{
    [JsonPropertyName("id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    [JsonPropertyName("internalId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InternalId { get; set; }

    [JsonPropertyName("action")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Action { get; set; }

    [JsonPropertyName("product")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AmendProductOrderRequestProductOrderItemProduct? Product { get; set; }

    [JsonPropertyName("appointment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AmendProductOrderRequestProductOrderItemAppointment? Appointment { get; set; }

    [JsonPropertyName("note")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AmendProductOrderRequestProductOrderItemNote? Note { get; set; }

    [JsonPropertyName("productOrderItem")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<AmendProductOrderRequestProductOrderItemProductOrderItem>? ProductOrderItem { get; set; }

    [JsonPropertyName("@type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }
}
