using System.Text.Json.Serialization;

namespace SDK.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum NotificationDeliveryType : byte
    {
        Push,
        Email,
        PushAndEmail
    }
}
