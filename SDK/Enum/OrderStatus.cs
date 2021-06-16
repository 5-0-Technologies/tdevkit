//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;

namespace Core.Enum
{

    //[JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus : byte
    {
        Created,
        Sent,
        Accepted,
        Aborted,
        Completed,
        Discarded
    }
}
