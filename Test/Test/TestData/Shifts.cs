using SDK.Contracts.Data;

namespace Test.TestData
{
    public static class Shifts
    {
        public static ShiftContract GetShift()
        {
            return new ShiftContract
            {
                Id = 1,
                Title = "shift1",
                BranchId = 1,
                StartTime = 1599644652178,
                StopTime = 1599644652178
            };
        }

        public static ShiftContract[] GetShifts()
        {
            return new[]
            {
                new ShiftContract
                {
                    Id = 1,
                    BranchId = 1,
                    Title = "shift1",
                    StartTime = 1599644652178,
                    StopTime = 1599644652178
                },
                new ShiftContract
                {
                    Id = 2,
                    BranchId = 1,
                    Title = "shift2",
                    StartTime = 1599644652178,
                    StopTime = 1599644652178
                }
            };
        }
    }
}
