using SDK.Models;
using SDK.Communication;
using System;

namespace Test.TestData
{
    public static class Sensors
    {
        public static SensorContract GetSensor()
        {
            return new SensorContract
            {
                Id = 1,
                Login = "sensor-login",
                Title = "Test Sensor",
                Mac = "00:00:00:00:00:01",
                Note = "Test note",
                X = 10.0f,
                Y = 20.0f,
                Battery = 99.9f,
                SectorId = 1,
                AreaId = 2,
                ExternalId = "ext-001",
                SensorTypeId = 1,
                Tags = "tag1"
            };
        }

        public static SensorContract[] GetSensors()
        {
            return new SensorContract[]
            {
                GetSensor(),
                new SensorContract
                {
                    Id = 2,
                    Login = "sensor-login-2",
                    Title = "Test Sensor 2",
                    Mac = "00:00:00:00:00:02",
                    Note = "Test note 2",
                    X = 11.0f,
                    Y = 21.0f,
                    Battery = 88.8f,
                    SectorId = 2,
                    AreaId = 3,
                    ExternalId = "ext-002"
                }
            };
        }

        public static SensorWriteContract GetSensorWriteContract()
        {
            return new SensorWriteContract
            {
                Login = "sensor-login",
                Title = "Test Sensor",
                Mac = "00:00:00:00:00:01",
                Note = "Test note",
                X = 10.0f,
                Y = 20.0f,
                Battery = 99.9f,
                SectorId = 1,
                AreaId = 2,
                ExternalId = "ext-001",
                SensorTypeId = 1,
                Tags = "tag1"
            };
        }

        public static SensorBatchContract[] GetSensorBatchContracts()
        {
            return new SensorBatchContract[]
            {
                new SensorBatchContract
                {
                    Login = "sensor-001",
                    Title = "Test Sensor",
                    Mac = "00:00:00:00:00:01",
                    SensorData = new SensorDataBatchContract[]
                    {
                        new SensorDataBatchContract
                        {
                            Quantity = "temperature",
                            Value = "25.5",
                            Unit = "C",
                            DataType = "Single",
                            Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                        }
                    }
                }
            };
        }

        public static SensorDataBatchContract[] GetSensorDataBatchContracts()
        {
            return new SensorDataBatchContract[]
            {
                new SensorDataBatchContract
                {
                    Quantity = "temperature",
                    Value = "25.5",
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    DataType = "Single"
                }
            };
        }

        public static SensorResponseContract[] GetSensorDataBatch()
        {
            return new SensorResponseContract[]
            {
                new SensorResponseContract
                {
                    Login = "sensor-001",
                    Success = true,
                    SensorData = new SensorDataResponseContract[]
                    {
                        new SensorDataResponseContract
                        {
                            Quantity = "temperature",
                            Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                            Success = true
                        }
                    }
                }
            };
        }

        public static SensorDataResponseContract[] GetSensorData()
        {
            return new SensorDataResponseContract[]
            {
                new SensorDataResponseContract
                {
                    Quantity = "temperature",
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                    Success = true
                }
            };
        }

        public static SensorAppInfoContract GetSensorAppInfo()
        {
            return new SensorAppInfoContract
            {
                Version = "1.0.0",
                Size = 123456,
                Name = "sensor-app.apk"
            };
        }

        public static SensorResponseContract[] GetAddSensorResponse()
        {
            return new SensorResponseContract[]
            {
                new SensorResponseContract
                {
                    Login = "sensor-login",
                    Success = true
                }
            };
        }
    }
}
