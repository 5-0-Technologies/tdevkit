using System;
using System.Collections.Generic;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_WorkRoleContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? NodeId { get; set; }

        public string NodeTitle { get; set; }

        public Guid? NodeGuid { get; set; }

        public List<AOS_WorkRoleContract> Children { get; set; }
    }
}
