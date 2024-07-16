using SDK.Models;

namespace Test.TestData
{
    public static partial class TestData
    {
        public static SectorContract GetSector()
        {
            return new()
            {
                BranchId = 1,
                Title = "sector-sdk",
                BarrierWidth = 10,
                BarrierHeight = 10,
                SectorWidth = 10000,
                SectorHeight = 10000
            };
        }
    }
}
