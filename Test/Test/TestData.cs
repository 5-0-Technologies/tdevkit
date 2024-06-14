using Core.Enum;
using SDK.Contracts.Data;
using SDK.Enum;
using SDK.Models;

namespace Main
{
    public static class TestData
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

        public static DeviceContract GetDevice()
        {
            DeviceContract device = new DeviceContract
            {
                Mac = "00:00:00:00:00:00",
                BranchId = 1,
                SectorId = 1,
                Login = "sdk-device",
                Title = "sdk-device",
                X = 10.0,
                Y = 10.0,
                //AppVersion = "1.0",
                IsMoving = false,
                FallStatus = FallType.OK,
                //Battery = 46f,
                DeviceTypeId = 8,
                Position = false,
                Geofence = false
            };
            return device;
        }

        public static DeviceLocationContract[] GetLocalizationDataBatch()
        {
            DistanceContract[] distanceContract1 =
            [
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
            ];

            LocationContract[] locationContract =
            [
                new LocationContract {SectorId = 1, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 2, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 3, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 4, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
            ];

            return [new DeviceLocationContract { Login = "rtu-sdk", Locations = locationContract }];
        }
        public static LocationContract[] GetLocalizationData()
        {
            DistanceContract[] distanceContract1 =
            [
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
            ];

            return
            [
                new LocationContract {SectorId = 1, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 2, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 3, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
                new LocationContract {SectorId = 4, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
                    X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
            ];
        }

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
            SensorDataContract data1 = new SensorDataContract
            {
                Quantity = "Temperature",
                Value = "16",
                Unit = "°C",
                DataType = SensorDataType.Decimal
            };
            SensorDataContract data2 = new SensorDataContract
            {
                Quantity = "Humidity",
                Value = "31",
                Unit = "%",
                DataType = SensorDataType.Decimal
            };
            SensorDataContract[] sensorDataContracts = [data1, data2];

            SensorContract sensor = new SensorContract
            {
                //Id = 7351,
                Login = "sdk-sensor",
                //Password = "sdk",
                Title = "sdk-sensor",
                SectorId = 2,
                SensorData = sensorDataContracts,
                //AreaId = 19
            };

            return sensor;
        }
        public static SensorContract GetSensorUpdate()
        {
            SensorContract sensor = new SensorContract
            {
                Id = 7351,
                Login = "sdk-sensor2",
                Title = "tests",
                SectorId = 2,
                AreaId = 19
            };

            return sensor;
        }
        public static SensorContract[] GetSensorDataBatch()
        {
            SensorDataContract data1 = new SensorDataContract
            {
                Quantity = "Temperature",
                Value = "16",
                Unit = "°C",
                DataType = SensorDataType.Decimal
            };
            SensorDataContract data2 = new SensorDataContract
            {
                Quantity = "Humidity",
                Value = "31",
                Unit = "%",
                DataType = SensorDataType.Decimal
            };
            SensorDataContract data3 = new SensorDataContract
            {
                Quantity = "CO2",
                Timestamp = 1614599484673,
                Value = "800",
                DataType = SensorDataType.Int32,
                Unit = "unit"
            };
            var sensorDataContracts = new[] { data1, data2, data3 };

            SensorContract sensor = new SensorContract
            {
                Login = "enviro-sdk",
                //SectorId = 2,
                SensorData = sensorDataContracts,
                //AreaId = 24
            };
            SensorContract[] sensorContracts = new SensorContract[] { sensor };

            return sensorContracts;
        }
        public static SensorDataContract[] GetSensorData()
        {
            SensorDataContract data1 = new SensorDataContract
            {
                Quantity = "Temperature",
                Value = "16",
                Unit = "°C",
                DataType = SensorDataType.Decimal
            };
            SensorDataContract data2 = new SensorDataContract
            {
                Quantity = "Humidity",
                Value = "31",
                Unit = "%",
                DataType = SensorDataType.Decimal
            };
            SensorDataContract data3 = new SensorDataContract
            {
                Quantity = "CO2",
                Timestamp = 1614599484673,
                Value = "800",
                DataType = SensorDataType.Int32,
                Unit = "unit"
            };

            SensorDataContract[] sensorDataContracts = [data1, data2, data3];

            return sensorDataContracts;
        }
    }
}
