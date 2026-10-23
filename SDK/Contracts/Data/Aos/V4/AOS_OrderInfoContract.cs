using SDK.Enum;
using System;
using System.Collections.Generic;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_OrderInfoContract
    {
        public Guid OrderGuid { get; set; }

        public OrderStatus2 OrderStatus { get; set; }

        public int PackageId { get; set; }

        public string PackageTitle { get; set; }

        public List<AOS_ItemContract> Items { get; set; } = new();

        public string Note { get; set; }

        public long Created { get; set; }

        public bool IsOwner { get; set; }

        public bool IsTarget { get; set; }

        public bool CanDiscard { get; set; }

        public string Creator { get; set; }

        public string WorkRoleCreator { get; set; }

        public string Sender { get; set; }

        public string WorkRoleSender { get; set; }

        public string Acceptor { get; set; }

        public string WorkRoleAcceptor { get; set; }
    }
}
