using System;
﻿
namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_DiscardActionContract
    {
        public Guid Order { get; set; }

        public string Note { get; set; }
    }

    public class AOS_MultiRoleDiscardActionContract : AOS_DiscardActionContract
    {
        public AOS_MultiRoleTargetImpersonationContract As { get; set; }
    }
}
