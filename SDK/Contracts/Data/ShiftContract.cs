using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SDK.Contracts.Data
{
    public class ShiftContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int BranchId { get; set; }

        public long StartTime { get; set; }

        public long StopTime { get; set; }

        public static explicit operator ShiftWriteContract(ShiftContract contract)
        {
            return new ShiftWriteContract
            {
                Title = contract.Title,
                StartTime = contract.StartTime,
                StopTime = contract.StopTime,
            };
        }
    }

    public class ShiftWriteContract
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public long StartTime { get; set; }

        public long StopTime { get; set; }
    }
}
