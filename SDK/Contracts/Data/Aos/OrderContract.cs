using Core.Enum;
//using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Core.Contract.V3.Aos
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
