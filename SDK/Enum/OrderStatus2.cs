using System.Text.Json.Serialization;

namespace SDK.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OrderStatus2 : byte
    {
        Created,
        Sent,
        Accepted,
        Aborted,
        Delivered,
        Completed,
        Discarded
    }
}
