using System.Text.Json.Serialization;

namespace SDK.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SensorDataType
    {
        Byte,
        SByte,
        Int32,
        UInt32,
        Int16,
        UInt16,
        Int64,
        UInt64,
        Single,
        Double,
        Char,
        Boolean,
        String,
        Decimal,
        DateTime,
        URL
    }
}