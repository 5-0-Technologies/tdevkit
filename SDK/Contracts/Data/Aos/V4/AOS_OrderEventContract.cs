using SDK.Enum;
using System;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_OrderEventContract
    {
        public int Id { get; set; }

        public int NodeId { get; set; }
        public Guid NodeGuid { get; set; }
        public string NodeTitle { get; set; }
        public int WorkRoleId { get; set; }
        public string WorkRoleTitle { get; set; }
        public int? AccountId { get; set; }
        public string AccountTitle { get; set; }
        public string AccountLogin { get; set; }
        public OrderStatus2? Status { get; set; }

        public long Created { get; set; }
    }
}
