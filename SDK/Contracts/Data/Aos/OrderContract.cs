using Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace SDK.Contracts.Data.Aos
{
    public class OrderContract
    {
        [Required]
        public Guid Guid { get; set; }

        public OrderStatus Status { get; set; }

        public string Note { get; set; }

        [Required]
        public ItemContract[] Items { get; set; }
    }
}
