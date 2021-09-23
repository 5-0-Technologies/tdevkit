using Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
