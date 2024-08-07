﻿using SDK.Contracts.Data;
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
                Title = "sdk-test",
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

        public static DeviceLocationContract[] GetLocalizationDataBatch()
        {
            DistanceContract[] distanceContract1 = new DistanceContract[3];
            distanceContract1[0] = new DistanceContract { BeaconId = 34, RSSI = -56 };
            distanceContract1[1] = new DistanceContract { BeaconId = 34, RSSI = -56 };
            distanceContract1[2] = new DistanceContract { BeaconId = 34, RSSI = -56 };

            LocationContract[] locationContract = new LocationContract[4];
            locationContract[0] = new LocationContract
            {
                SectorId = 1,
                Battery = 100,
                IsMoving = true,
                Timestamp = 1599644652178,
                X = 0,
                Y = 0,
                Z = 0,
                Interval = 300,
                Distances = distanceContract1
            };
            locationContract[1] = new LocationContract
            {
                SectorId = 2,
                Battery = 100,
                IsMoving = true,
                Timestamp = 1599644652178,
                X = 0,
                Y = 0,
                Z = 0,
                Interval = 300,
                Distances = distanceContract1
            };
            locationContract[2] = new LocationContract
            {
                SectorId = 3,
                Battery = 100,
                IsMoving = true,
                Timestamp = 1599644652178,
                X = 0,
                Y = 0,
                Z = 0,
                Interval = 300,
                Distances = distanceContract1
            };
            locationContract[3] = new LocationContract
            {
                SectorId = 4,
                Battery = 100,
                IsMoving = true,
                Timestamp = 1599644652178,
                X = 0,
                Y = 0,
                Z = 0,
                Interval = 300,
                Distances = distanceContract1
            };

            DeviceLocationContract[] deviceLocationContracts = new DeviceLocationContract[1];
            deviceLocationContracts[0] = new DeviceLocationContract { Login = "sdk-device", Locations = locationContract };

            return deviceLocationContracts;
        }
        public static LocationContract[] GetLocalizationData()
        {
            DistanceContract[] distanceContract1 = new DistanceContract[3];
            distanceContract1[0] = new DistanceContract { BeaconId = 34, RSSI = -56 };
            distanceContract1[1] = new DistanceContract { BeaconId = 34, RSSI = -56 };
            distanceContract1[2] = new DistanceContract { BeaconId = 34, RSSI = -56 };

            LocationContract[] locationContract = new LocationContract[4];
            locationContract[0] = new LocationContract
            {
                SectorId = 1,
                Battery = 100,
                IsMoving = true,
                Timestamp = 1599644652178,
                X = 0,
                Y = 0,
                Z = 0,
                Interval = 300,
                Distances = distanceContract1
            };
            locationContract[1] = new LocationContract
            {
                SectorId = 2,
                Battery = 100,
                IsMoving = true,
                Timestamp = 1599644652178,
                X = 0,
                Y = 0,
                Z = 0,
                Interval = 300,
                Distances = distanceContract1
            };
            locationContract[2] = new LocationContract
            {
                SectorId = 3,
                Battery = 100,
                IsMoving = true,
                Timestamp = 1599644652178,
                X = 0,
                Y = 0,
                Z = 0,
                Interval = 300,
                Distances = distanceContract1
            };
            locationContract[3] = new LocationContract
            {
                SectorId = 4,
                Battery = 100,
                IsMoving = true,
                Timestamp = 1599644652178,
                X = 0,
                Y = 0,
                Z = 0,
                Interval = 300,
                Distances = distanceContract1
            };

            return locationContract;
        }

        public static SensorContract GetSensor()
        {
            SensorDataContract data1 = new SensorDataContract
            {
                Quantity = "Temperature",
                Value = "16",
                Unit = "°C",
                DataType = SensorDataType.Decimal,
                Index = 0
            };
            SensorDataContract data2 = new SensorDataContract
            {
                Quantity = "Humidity",
                Value = "31",
                Unit = "%",
                DataType = SensorDataType.Decimal,
                Index = 1
            };
            SensorDataContract[] sensorDataContracts = new SensorDataContract[2];
            sensorDataContracts[0] = data1;
            sensorDataContracts[1] = data2;

            SensorContract sensor = new SensorContract
            {
                Id = 7351,
                Login = "sdk-sensor2",
                Title = "testtt",
                SectorId = 2,
                SensorData = sensorDataContracts,
                AreaId = 19
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
                DataType = SensorDataType.Decimal,
                Index = 0
            };
            SensorDataContract data2 = new SensorDataContract
            {
                Quantity = "Humidity",
                Value = "31",
                Unit = "%",
                DataType = SensorDataType.Decimal,
                Index = 1
            };
            SensorDataContract data3 = new SensorDataContract
            {
                Quantity = "CO2",
                Timestamp = 1614599484673,
                Value = "800",
                DataType = SensorDataType.Int32,
                Unit = "unit",
                Index = 2
            };
            SensorDataContract[] sensorDataContracts = new SensorDataContract[3];
            sensorDataContracts[0] = data1;
            sensorDataContracts[1] = data2;
            sensorDataContracts[2] = data3;

            SensorContract sensor = new SensorContract
            {
                Login = "sdk-sensor",
                SectorId = 2,
                SensorData = sensorDataContracts,
                AreaId = 24
            };
            SensorContract[] sensorContracts = new SensorContract[1];
            sensorContracts[0] = sensor;

            return sensorContracts;
        }
        public static SensorDataContract[] GetSensorData()
        {
            SensorDataContract data1 = new SensorDataContract
            {
                Quantity = "Temperature",
                Value = "16",
                Unit = "°C",
                DataType = SensorDataType.Decimal,
                Index = 0
            };
            SensorDataContract data2 = new SensorDataContract
            {
                Quantity = "Humidity",
                Value = "31",
                Unit = "%",
                DataType = SensorDataType.Decimal,
                Index = 1
            };
            SensorDataContract data3 = new SensorDataContract
            {
                Quantity = "CO2",
                Timestamp = 1614599484673,
                Value = "800",
                DataType = SensorDataType.Int32,
                Unit = "unit",
                Index = 2
            };
            SensorDataContract[] sensorDataContracts = new SensorDataContract[3];
            sensorDataContracts[0] = data1;
            sensorDataContracts[1] = data2;
            sensorDataContracts[2] = data3;

            return sensorDataContracts;
        }

        public static ShiftContract GetShift()
        {
            return new ShiftContract
            {
                Id = 1,
                Title = "shift1",
                BranchId = 1,
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
                    Id = 1,
                    Title = "shift1",
                    BranchId = 1,
                    StartTime = 1599644652178,
                    StopTime = 1599644652178
                },
                new ShiftContract
                {
                    Id = 2,
                    Title = "shift2",
                    BranchId = 1,
                    StartTime = 1599644652178,
                    StopTime = 1599644652178
                }
            };
        }
    }
}
