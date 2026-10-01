using System.Text.Json;
using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

public class BTProductOrderItem
{
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("action")]
    public required OrderItemActionType Action { get; set; }

    [JsonPropertyName("appointment")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BTAppointmentRef? Appointment { get; set; }

    [JsonPropertyName("billingAccount")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BillingAccountRefs? BillingAccount { get; set; }

    [JsonPropertyName("product")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BTProductRefOrValue? Product { get; set; }

    [JsonPropertyName("productOffering")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BTProductOfferingRef? ProductOffering { get; set; }

    [JsonPropertyName("productOfferingQualificationItem")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ProductOfferingQualificationItemRef? ProductOfferingQualificationItem { get; set; }

    [JsonPropertyName("productOrderItem")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<BTProductOrderItem>? ProductOrderItem { get; set; }

    [JsonPropertyName("productOrderItemRelationship")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<OrderItemRelationship>? ProductOrderItemRelationship { get; set; }

    [JsonPropertyName("qualification")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<ProductOfferingQualificationRef>? Qualification { get; set; }

    [JsonPropertyName("state")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ProductOrderItemStateType? State { get; set; }

    [JsonPropertyName("@baseType")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? BaseType { get; set; }

    [JsonPropertyName("@type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Type { get; set; }

    [JsonPropertyName("internalId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InternalId { get; set; }

    [JsonPropertyName("subStatus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? SubStatus { get; set; }

    [JsonPropertyName("note")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BTNote? Note { get; set; }

    [JsonPropertyName("additionalNotes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<BTNote>? AdditionalNotes { get; set; }

    [JsonPropertyName("amendmentStatus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PONRType? AmendmentStatus { get; set; }

    [JsonPropertyName("cancellationStatus")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PONRType? CancellationStatus { get; set; }

    [JsonPropertyName("requestedCompletionDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? RequestedCompletionDate { get; set; }

    [JsonPropertyName("expectedCompletionDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? ExpectedCompletionDate { get; set; }

    [JsonPropertyName("completionDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTimeOffset? CompletionDate { get; set; }
}
