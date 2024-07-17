using SDK.Models;

namespace Test.TestData
{
    public static class Quantities
    {
        public static QuantityContract GetQuantity()
        {
            return new QuantityContract()
            {
                Id = 1,
                BranchId = 1,
                Title = "quantity",
                Range = new RangeContract
                {
                    Type = "type",
                    Ranges = new[]
                    {
                        new RangesContract
                        {
                            Color = "color",
                            Value = "value"
                        },
                        new RangesContract
                        {
                            Color = "color",
                            Value = "value"
                        }
                    }
                }
            };
        }

        public static QuantityContract[] GetQuantities()
        {
            return new[]
            {
                new QuantityContract
                {
                    Id = 1,
                BranchId = 1,
                Title = "quantity1",
                Range = new RangeContract
                {
                    Type = "type",
                    Ranges = new[]
                    {
                        new RangesContract
                        {
                            Color = "color",
                            Value = "value"
                        },
                        new RangesContract
                        {
                            Color = "color",
                            Value = "value"
                        }
                    }
                }
                },
                new QuantityContract
                {
                    Id = 2,
                BranchId = 1,
                Title = "quantity2",
                Range = new RangeContract
                {
                    Type = "type",
                    Ranges = new[]
                    {
                        new RangesContract
                        {
                            Color = "color",
                            Value = "value"
                        },
                        new RangesContract
                        {
                            Color = "color",
                            Value = "value"
                        }
                    }
                }
                }
            };
        }
    }
}
