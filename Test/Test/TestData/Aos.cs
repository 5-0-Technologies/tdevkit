using SDK.Contracts.Data.Aos;
using System;

namespace Test.TestData
{
    public static class Aos
    {
        public static OrderDataContract[] GetOrders()
        {
            return new OrderDataContract[]
            {
                new OrderDataContract
                {
                    OrderId = 1,
                    Status = 1,
                    CreatedBy = 1,
                    LastUpdatedBy = 1,
                    Duration = 3600000,
                    ItemCount = 5,
                    ItemList = "Item1,Item2,Item3",
                    Created = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Updated = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Notes = "Test order 1"
                },
                new OrderDataContract
                {
                    OrderId = 2,
                    Status = 2,
                    CreatedBy = 1,
                    LastUpdatedBy = 1,
                    Duration = 7200000,
                    ItemCount = 3,
                    ItemList = "Item4,Item5",
                    Created = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Updated = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Notes = "Test order 2"
                }
            };
        }
    }
} 