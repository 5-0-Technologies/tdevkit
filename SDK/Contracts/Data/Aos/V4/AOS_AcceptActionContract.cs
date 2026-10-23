using System;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_AcceptActionContract
    {
        public Guid Order { get; set; }

        public string Note { get; set; }
    }

    public class AOS_MultiRoleAcceptActionContract : AOS_AcceptActionContract
    {
        public AOS_MultiRoleTargetImpersonationContract As { get; set; }
    }
}
