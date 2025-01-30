using System;
using System.Collections.Generic;
using SDK.Models;

namespace Test.TestData
{
    public static class Paths
    {
        public static readonly Guid TestPathId1 = new Guid("11111111-1111-1111-1111-111111111111");
        public static readonly Guid TestPathId2 = new Guid("22222222-2222-2222-2222-222222222222");

        public static PathContract GetTestPath(Guid guid) => new PathContract
        {
            Id = 1,
            Title = $"Test Path 1",
            Description = "A test path for unit testing",
            BranchId = 1,
            SectorId = 1,
            LayerId = 1,
            Guid = guid,
            PathPoints = new [] 
            { 
                new PathPointContract
                {
                    Id = 1,
                    X = 0,
                    Y = 0,
                }, 
                new PathPointContract
                {
                    Id = 2,
                    X = 10,
                    Y = 10,
                } 
            }
        };

        public static IEnumerable<PathContract> GetTestPaths()
        {
            return new List<PathContract>
            {
                GetTestPath(TestPathId1),
                GetTestPath(TestPathId2)
            };
        }
    }
}
