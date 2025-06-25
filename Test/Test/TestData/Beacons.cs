using SDK.Models;
using System;

namespace Test.TestData
{
    public static class Beacons
    {
        public static BeaconContract GetBeacon()
        {
            return new BeaconContract
            {
                Id = 1,
                Title = "Test Beacon",
                BranchId = 1,
                SectorId = 1,
                X = 10.0,
                Y = 10.0,
                Z = 0.0,
                Active = true,
                Position = true,
                Geofence = true,
                GeofenceRange = 20.0,
                Cluster = "c1",
                UseGps = false,
                Created = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Update = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
        }

        public static BeaconContract[] GetBeacons()
        {
            return new BeaconContract[]
            {
                new BeaconContract
                {
                    Id = 1,
                    Title = "Test Beacon 1",
                    BranchId = 1,
                    SectorId = 1,
                    X = 10.0,
                    Y = 10.0,
                    Z = 0.0,
                    Active = true,
                    Position = true,
                    Geofence = true,
                    GeofenceRange = 20.0,
                    Cluster = "c1",
                    UseGps = false,
                    Created = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Update = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                },
                new BeaconContract
                {
                    Id = 2,
                    Title = "Test Beacon 2",
                    BranchId = 1,
                    SectorId = 1,
                    X = 20.0,
                    Y = 20.0,
                    Z = 0.0,
                    Active = true,
                    Position = true,
                    Geofence = true,
                    GeofenceRange = 20.0,
                    Cluster = "c2",
                    UseGps = false,
                    Created = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Update = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                }
            };
        }

        public static BeaconContract GetBeaconPatch()
        {
            return new BeaconContract
            {
                Id = 148,
                SectorId = 1,
                BranchId = 1,
                Mac = "aa:aa:aa:aa:aa:ac",
                X = 0,
                Y = 0,
                Z = 0,
                Title = "sdk-test",
                Active = true,
                TypeId = 24,
                Position = true,
                Geofence = true,
                GeofenceRange = 20,
                Cluster = "c1",
                UseGps = false,
            };
        }
    }
}
