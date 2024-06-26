﻿using System.Text.Json.Serialization;

namespace Core.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FallType : byte
    {
        OK = 0,
        ManDown = 1,
        ManDownControl = 2,
        ManDownPositive = 3,
        ManDownNegative = 4,
        ManDownNegativeAfterLimit = 5
    }
}
