using System;
﻿
namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_DeliverActionContract
    {
        public Guid Order { get; set; }

        public string Note { get; set; }
    }

    public class AOS_MultiRoleDeliverActionContract : AOS_DeliverActionContract
    {
        public AOS_MultiRoleTargetImpersonationContract As { get; set; }
    }
}
