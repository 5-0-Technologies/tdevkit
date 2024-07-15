using Core.Enum;
using SDK.Contracts.Data;
using SDK.Enum;
using SDK.Models;

namespace Main
{
    public static class TestData
    {
        #region Beacons
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
        #endregion

        #region Sectors
        public static SectorContract GetSector()
        {
            return new()
            {
                BranchId = 1,
                Title = "sector-sdk",
                BarrierWidth = 10,
                BarrierHeight = 10,
                SectorWidth = 10000,
                SectorHeight = 10000
            };
        }
        public static SensorContract GetSensor()
        {
            return new SensorContract
            {
                Login = "sdk-sensor1",
                SensorData = new[]
            {
                new SensorDataContract
                {
                    Quantity = "Temperature",
                    Value = "16",
                    Unit = "°C",
                    DataType = SensorDataType.Decimal
                },
                new SensorDataContract
                {
                    Quantity = "Humidity",
                    Value = "31",
                    Unit = "%",
                    DataType = SensorDataType.Decimal
                },
                new SensorDataContract
                {
                    Quantity = "CO2",
                    Timestamp = 1614599484673,
                    Value = "800",
                    DataType = SensorDataType.Int32,
                    Unit = "unit"
                }
                }
            };
        }
        public static SensorContract GetSensorUpdate()
        {
            return new SensorContract
            {
                Id = 7351,
                Login = "sdk-sensor2",
                Title = "tests",
                SectorId = 2,
                AreaId = 19
            };
        }
        public static SensorContract[] GetSensorDataBatch()
        {
            return new[]
            {
                new SensorContract
                {
                    Login = "sdk-sensor1",
                    SensorData = GetSensorData()
                },
                new SensorContract
                {
                    Login = "sdk-sensor2",
                    SensorData = GetSensorData()
                }
            };
        }
        public static SensorDataContract[] GetSensorData()
        {
            return new[]
            {
                new SensorDataContract
                {
                    Quantity = "Temperature",
                    Value = "16",
                    Unit = "°C",
                    DataType = SensorDataType.Decimal
                },
                new SensorDataContract
                {
                    Quantity = "Humidity",
                    Value = "31",
                    Unit = "%",
                    DataType = SensorDataType.Decimal
                },
                new SensorDataContract
                {
                    Quantity = "CO2",
                    Timestamp = 1614599484673,
                    Value = "800",
                    DataType = SensorDataType.Int32,
                    Unit = "unit"
                }
            };
        }
        #endregion

        #region Shifts
        public static ShiftContract GetShift()
        {
            return new ShiftContract
            {
                BranchId = 1,
                Title = "shift1",
                StartTime = 1599644652178,
                StopTime = 1599644652178
            };
        }
        public static ShiftContract[] GetShifts()
        {
            return new[]
            {
                new ShiftContract
                {
                    BranchId = 1,
                    Title = "shift1",
                    StartTime = 1599644652178,
                    StopTime = 1599644652178
                },
                new ShiftContract
                {
                    BranchId = 1,
                    Title = "shift2",
                    StartTime = 1599644652178,
                    StopTime = 1599644652178
                }
            };
        }
        #endregion
    }
}
