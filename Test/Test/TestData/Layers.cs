using SDK.Contracts.Data;

namespace Test.TestData
{
    public static class Layers
    {
        public static LayerContract GetLayer()
        {
            return new LayerContract
            {
                Id = 1,
                Title = "layer1",
                BranchId = 1,
            };
        }

        public static LayerContract[] GetLayers()
        {
            return new[]
            {
                new LayerContract
                {
                    Id = 1,
                    Title = "layer1",
                    BranchId = 1,
                },
                new LayerContract
                {
                    Id = 2,
                    Title = "layer2",
                    BranchId = 1,
                }
            };
        }
    }
}
