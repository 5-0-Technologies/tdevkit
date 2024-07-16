using SDK.Contracts.Data;

namespace Test.TestData
{
    public static partial class TestData
    {
        public static ShiftContract GetShift()
        {
            return new ShiftContract
            {
                BranchId = 1,
                Title = "shift1",
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
                    BranchId = 1,
                    Title = "shift1",
                    StartTime = 1599644652178,
                    StopTime = 1599644652178
                },
                new ShiftContract
                {
                    BranchId = 1,
                    Title = "shift2",
                    StartTime = 1599644652178,
                    StopTime = 1599644652178
                }
            };
        }
    }
}
