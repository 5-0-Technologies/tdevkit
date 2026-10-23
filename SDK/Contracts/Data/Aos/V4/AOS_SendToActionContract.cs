using System;
using System.Collections.Generic;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_SendToActionContract
    {
        public Guid Order { get; set; }

        public List<AOS_SimpleTargetContract> Targets { get; set; } = new List<AOS_SimpleTargetContract>();

        public string Note { get; set; }
    }

    public class AOS_MultiRoleSendToActionContract : AOS_SendToActionContract
    {
        public AOS_MultiRoleTargetImpersonationContract As { get; set; }
    }
}
