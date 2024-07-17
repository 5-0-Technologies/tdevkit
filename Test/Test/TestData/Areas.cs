using SDK.Models;
using System;

namespace Test.TestData
{
    public static class Areas
    {
        public static AreaContract GetArea()
        {
            return new AreaContract
            {
                Id = 1,
                BranchId = 1,
                Guid = Guid.NewGuid(),
                Title = "area1",
                Color = "red",
                SectorId = 1,
                LayerId = 1,
                Description = "description",
                Created = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Updated = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Coordinates = new[]
                {
                    new PointContract
                    {
                        X = 0,
                        Y = 0
                    },
                    new PointContract
                    {
                        X = 0,
                        Y = 100
                    },
                    new PointContract
                    {
                        X = 100,
                        Y = 100
                    },
                    new PointContract
                    {
                        X = 100,
                        Y = 0
                    }
                }

            };
        }

        public static AreaContract[] GetAreas()
        {
            return new[]
            {
                new AreaContract
                {
                    Id = 1,
                    BranchId = 1,
                    Guid = Guid.NewGuid(),
                    Title = "area1",
                    Color = "red",
                    SectorId = 1,
                    LayerId = 1,
                    Description = "description",
                    Created = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Updated = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Coordinates = new[]
                    {
                        new PointContract
                        {
                            X = 0,
                            Y = 0
                        },
                        new PointContract
                        {
                            X = 0,
                            Y = 100
                        },
                        new PointContract
                        {
                            X = 100,
                            Y = 100
                        },
                        new PointContract
                        {
                            X = 100,
                            Y = 0
                        }
                    }
                },
                new AreaContract
                {
                    Id = 2,
                    BranchId = 1,
                    Guid = Guid.NewGuid(),
                    Title = "area2",
                    Color = "red",
                    SectorId = 1,
                    LayerId = 1,
                    Description = "description",
                    Created = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Updated = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Coordinates = new[]
                    {
                        new PointContract
                        {
                            X = 0,
                            Y = 0
                        },
                        new PointContract
                        {
                            X = 0,
                            Y = 100
                        },
                        new PointContract
                        {
                            X = 100,
                            Y = 100
                        },
                        new PointContract
                        {
                            X = 100,
                            Y = 0
                        }
                    }
                }
            };
        }
    }
}
