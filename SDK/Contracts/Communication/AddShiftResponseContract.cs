using SDK.Communication;
using SDK.Contracts.Data;

namespace SDK.Contracts.Communication
{
    public class AddShiftResponseContract : PostResponseContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int BranchId { get; set; }

        public long StartTime { get; set; }

        public long StopTime { get; set; }

        public static explicit operator ShiftContract(AddShiftResponseContract addShiftResponseContract)
        {
            return new ShiftContract
            {
                Id = addShiftResponseContract.Id,
                Title = addShiftResponseContract.Title,
                BranchId = addShiftResponseContract.BranchId,
                StartTime = addShiftResponseContract.StartTime,
                StopTime = addShiftResponseContract.StopTime
            };
        }
    }
}