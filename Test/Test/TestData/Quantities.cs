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
                    type = "type",
                    ranges = new[]
                    {
                        new RangesContract
                        {
                            color = "color",
                            value = "value"
                        },
                        new RangesContract
                        {
                            color = "color",
                            value = "value"
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
                    type = "type",
                    ranges = new[]
                    {
                        new RangesContract
                        {
                            color = "color",
                            value = "value"
                        },
                        new RangesContract
                        {
                            color = "color",
                            value = "value"
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
                    type = "type",
                    ranges = new[]
                    {
                        new RangesContract
                        {
                            color = "color",
                            value = "value"
                        },
                        new RangesContract
                        {
                            color = "color",
                            value = "value"
                        }
                    }
                }
                }
            };
        }
    }
}
