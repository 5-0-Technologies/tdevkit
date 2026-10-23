using System;
﻿
namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_CompleteActionContract
    {
        public Guid Order { get; set; }

        public string Note { get; set; }
    }

    public class AOS_MultiRoleCompleteActionContract : AOS_CompleteActionContract
    {
        public AOS_MultiRoleTargetImpersonationContract As { get; set; }
    }
}
