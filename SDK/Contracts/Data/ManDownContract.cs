using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Data
{
    [DataContract]
    public class ManDownBatchContract
    {
        [Required]
        [StringLength(255)]
        [DataMember(Order = 1)]
        public string Login { get; set; }

        [Required]
        [DataMember(Order = 2)]
        public long Timestamp { get; set; }

        [Required]
        [DataMember(Order = 3)]
        public FallType FallType { get; set; }
    }
}
