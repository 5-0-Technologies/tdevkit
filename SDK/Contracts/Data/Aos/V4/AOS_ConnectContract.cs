using System;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_ConnectContract
    {
        public Guid NodeGuid { get; set; }

        public int WorkRoleId { get; set; }
    }

    public class AOS_ConnectIdContract
    {
        public int? NodeId { get; set; }

        public int? WorkRoleId { get; set; }

        public Guid OrderGuid { get; set; }
    }
}
