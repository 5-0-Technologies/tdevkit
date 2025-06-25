using SDK.Models;
using System;

namespace Test.TestData
{
    public static class Branches
    {
        public static BranchContract GetBranch()
        {
            return new BranchContract
            {
                Id = 1,
                Guid = "00000000-0000-0000-0000-000000000001",
                Title = "Test Branch",
                TimeZone = "UTC",
                Latitude = 0.0,
                Longitude = 0.0
            };
        }

        public static BranchContract[] GetBranches()
        {
            return new BranchContract[]
            {
                new BranchContract
                {
                    Id = 1,
                    Guid = "00000000-0000-0000-0000-000000000001",
                    Title = "Test Branch 1",
                    TimeZone = "UTC",
                    Latitude = 0.0,
                    Longitude = 0.0
                },
                new BranchContract
                {
                    Id = 2,
                    Guid = "00000000-0000-0000-0000-000000000002",
                    Title = "Test Branch 2",
                    TimeZone = "UTC",
                    Latitude = 0.0,
                    Longitude = 0.0
                }
            };
        }
    }
} 