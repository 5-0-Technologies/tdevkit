using Core.Enum;
using Microsoft.AspNetCore.Http;
using SDK.Contracts.Data;
using SDK.Models;

namespace Test.TestData
{
    public static partial class TestData
    {
        public static DeviceContract GetDevice()
        {
            return new DeviceContract
            {
                Mac = "00:00:00:00:00:00",
                BranchId = 1,
                SectorId = 1,
                Login = "sdk-device",
                Title = "sdk-device",
                X = 10.0,
                Y = 10.0,
                IsMoving = false,
                FallStatus = FallType.OK,
                DeviceTypeId = 8,
                Position = false,
                Geofence = false
            };
        }

        public static DeviceLocationContract[] GetLocalizationDataBatch()
        {
            DistanceContract[] distanceContract1 = new[]
            {
                new DistanceContract { BeaconId = 34, RSSI = -56 },
                new DistanceContract { BeaconId = 34, RSSI = -56 },
                new DistanceContract { BeaconId = 34, RSSI = -56 },
            };

            return new[] { new DeviceLocationContract { Login = "rtu-sdk", Locations =  new[]
            {
                new LocationContract {SectorId = 1, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 2, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 3, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 4, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                }
            }};
        }
        public static LocationContract[] GetLocalizationData()
        {
            DistanceContract[] distanceContract1 = new[]
            {
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
            };

            return new[]
            {
                new LocationContract {SectorId = 1, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 2, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 3, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 4, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
            };
        }
    }
}
