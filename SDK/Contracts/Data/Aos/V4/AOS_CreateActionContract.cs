using System.Collections.Generic;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_CreateActionContract
    {
        public int PackageId { get; set; }

        public List<AOS_ItemContract> Items { get; set; } = new List<AOS_ItemContract>();

        public string Note { get; set; }
    }

    public class AOS_MultiRoleCreateActionContract : AOS_CreateActionContract
    {
        public AOS_MultiRoleTargetImpersonationContract As { get; set; }
    }
}
