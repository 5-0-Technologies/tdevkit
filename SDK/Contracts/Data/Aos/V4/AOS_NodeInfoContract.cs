using System;
using System.Collections.Generic;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_NodeInfoContract
    {
        public Guid Guid { get; set; }

        public string Title { get; set; }

        public string WorkRole { get; set; }

        public int WorkRoleId { get; set; }

        public List<AOS_PackageContract> Packages { get; set; }

        public bool AutoOrderSending { get; set; }

        public bool AutoItemSelection { get; set; }
    }
}
