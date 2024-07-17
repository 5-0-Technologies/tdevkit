using SDK.Models;

namespace Test.TestData
{
    public static class Beacons
    {
        public static BeaconContract GetBeacon()
        {
            return new BeaconContract
            {
                SectorId = 1,
                BranchId = 1,
                Mac = "aa:aa:aa:aa:aa:aa",
                X = 0,
                Y = 0,
                Z = 0,
                Title = "sdk-beacon",
                Active = true,
                TypeId = 23,
                Position = true,
                Geofence = true,
                GeofenceRange = 20,
                Cluster = "c1",
                UseGps = false,
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
