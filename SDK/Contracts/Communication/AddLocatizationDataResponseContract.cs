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
    public class AddLocatizationDataResponseContract : PostResponseContract
    {
        public string Login { get; set; }

        public List<LocationResponseContract> Locations { get; set; }
    }

    public class LocationResponseContract
    {
        public long Timestamp { get; set; }

        public string Action { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
}
