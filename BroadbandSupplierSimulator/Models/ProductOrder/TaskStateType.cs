using System.Text.Json.Serialization;

namespace BroadbandSupplierSimulator.Models.ProductOrder;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaskStateType
{
    [JsonStringEnumMemberName("acknowledged")]
    Acknowledged,
    [JsonStringEnumMemberName("terminatedWithError")]
    TerminatedWithError,
    [JsonStringEnumMemberName("inProgress")]
    InProgress,
    [JsonStringEnumMemberName("done")]
    Done
}
