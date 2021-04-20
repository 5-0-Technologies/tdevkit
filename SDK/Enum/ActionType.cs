using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SDK.Enum
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum ActionType : byte
    {
        NoAction,
        Create,
        Update,
        Delete
    }
}
