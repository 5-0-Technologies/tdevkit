using SDK.Communication;
using System.Collections.Generic;

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
