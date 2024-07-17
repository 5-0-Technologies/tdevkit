using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SDK.Models
{
    [DataContract]
    public class QuantityContract
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public int BranchId { get; set; }

        [DataMember(Order = 3)]
        [StringLength(255)]
        public string Title { get; set; }

        [DataMember(Order = 4)]
        public RangeContract Range { get; set; }
    }

    [DataContract]
    public class RangeContract
    {
        [Required]
        [DataMember(Order = 1)]
        public string Type { get; set; }

        [Required]
        [DataMember(Order = 2)]
        public RangesContract[] Ranges { get; set; }
    }


    [DataContract]
    public class RangesContract
    {
        [Required]
        [DataMember(Order = 1)]
        public string Color { get; set; }

        [Required]
        [DataMember(Order = 2)]
        public string Value { get; set; }
    }
}
