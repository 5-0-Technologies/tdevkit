using System;
﻿
namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_SimpleTargetContract
    {
        /// <summary>
        /// Optional, because it is possible to send to a WorkRole only and let the system figure out the nodes that have the workRole and send to them.
        /// </summary>
        public Guid? NodeGuid { get; set; }

        public int WorkRoleId { get; set; }
    }

    public class AOS_TargetContract
    {
        public Guid NodeGuid { get; set; }

        public AOS_WorkRoleContract WorkRole { get; set; }
    }
}
