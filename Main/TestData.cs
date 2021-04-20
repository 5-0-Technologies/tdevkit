﻿using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public static class TestData
    {
        public static DeviceLocationContract[] GetLocalizationDataBatch()
        {
            DistanceContract[] distanceContract1 = new DistanceContract[]
            {
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
            };

            LocationContract[] locationContract = new LocationContract[]
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

            return new DeviceLocationContract[] { new DeviceLocationContract { Login = "sdk-device", Locations = locationContract } };
        }
        public static LocationContract[] GetLocalizationData()
        {
            DistanceContract[] distanceContract1 = new DistanceContract[]
            {
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
                new DistanceContract {BeaconId = 34, RSSI= -56},
            };

            return new LocationContract[]
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

        public static SensorContract[] GetSensorDataBatch()
        {
            SensorDataContract data1 = new SensorDataContract
            {
                Quantity = "Temperature",
                Value = "16",
                Unit = "°C",
                DataType = "Single"
            };
            SensorDataContract data2 = new SensorDataContract
            {
                Quantity = "Humidity",
                Value = "31",
                Unit = "%",
                DataType = "Single"
            };
            SensorDataContract data3 = new SensorDataContract
            {
                Quantity = "CO2",
                Timestamp = 1614599484673,
                Value = "800",
                DataType = "Int32",
                Unit = "unit"
            };
            SensorDataContract[] sensorDataContracts = new SensorDataContract[] { data1, data2, data3 };

            SensorContract sensor = new SensorContract
            {
                Login = "sdk-sensor",
                SectorId = 2,
                SensorData = sensorDataContracts,
                AreaId = 24
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
                DataType = "Single"
            };
            SensorDataContract data2 = new SensorDataContract
            {
                Quantity = "Humidity",
                Value = "31",
                Unit = "%",
                DataType = "Single"
            };
            SensorDataContract data3 = new SensorDataContract
            {
                Quantity = "CO2",
                Timestamp = 1614599484673,
                Value = "800",
                DataType = "Int32",
                Unit = "unit"
            };
            SensorDataContract[] sensorDataContracts = new SensorDataContract[] { data1, data2, data3 };

            return sensorDataContracts;
        }
    }
}
