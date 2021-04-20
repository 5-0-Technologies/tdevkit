using SDK.Communication;
using SDK.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Communication
{
    [DataContract]
    public class AddLocatizationDataResponseContract : PostResponseContract
    {
        [DataMember(Order = 1)]
        public string Login { get; set; }

        [DataMember(Order = 2)]
        public List<LocationResponseContract> Locations { get; set; }
    }

    [DataContract]
    public class LocationResponseContract
    {
        [DataMember(Order = 1)]
        public long Timestamp { get; set; }

        [DataMember(Order = 2)]
        public string Action { get; set; }

        [DataMember(Order = 3)]
        public bool Success { get; set; }

        [DataMember(Order = 4)]
        public string ErrorMessage { get; set; }
    }
}
