using System;
﻿
namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_AbortActionContract
    {
        public Guid Order { get; set; }

        public string Note { get; set; }
    }

    public class AOS_MultiRoleAbortActionContract : AOS_AbortActionContract
    {
        public AOS_MultiRoleTargetImpersonationContract As { get; set; }
    }
}
