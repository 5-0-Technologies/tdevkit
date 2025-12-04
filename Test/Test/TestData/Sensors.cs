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
                Title = "Test Sensor",
                Mac = "00:00:00:00:00:01",
                Note = "Test note",
                X = 10.0,
                Y = 20.0,
                Battery = 99.9f,
                SectorId = 1,
                AreaId = 2,
                ExternalId = "ext-001"
            };
        }

        public static SensorContract[] GetSensors()
        {
            return new SensorContract[]
            {
                new SensorContract
                {
                    Id = 1,
                    Title = "Test Sensor 1",
                    Mac = "00:00:00:00:00:01",
                    Note = "Test note 1",
                    X = 10.0,
                    Y = 20.0,
                    Battery = 99.9f,
                    SectorId = 1,
                    AreaId = 2,
                    ExternalId = "ext-001"
                },
                new SensorContract
                {
                    Id = 2,
                    Title = "Test Sensor 2",
                    Mac = "00:00:00:00:00:02",
                    Note = "Test note 2",
                    X = 11.0,
                    Y = 21.0,
                    Battery = 88.8f,
                    SectorId = 2,
                    AreaId = 3,
                    ExternalId = "ext-002"
                }
            };
        }

        public static SensorWriteContract[] GetSensorWriteContracts()
        {
            return new SensorWriteContract[]
            {
                new SensorWriteContract
                {
                    Title = "Test Sensor",
                    Mac = "00:00:00:00:00:01",
                    Note = "Test note",
                    X = 10.0f,
                    Y = 20.0f,
                    Battery = 99.9f,
                    SectorId = 1,
                    AreaId = 2,
                    ExternalId = "ext-001"
                }
            };
        }

        public static SensorDataWriteContract[] GetSensorDataWriteContracts()
        {
            return new SensorDataWriteContract[]
            {
                new SensorDataWriteContract
                {
                    SensorId = 1,
                    Quantity = "temperature",
                    Value = "25.5",
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                }
            };
        }

        public static AddSensorDataResponseContract[] GetSensorDataBatch()
        {
            return new AddSensorDataResponseContract[]
            {
                new AddSensorDataResponseContract
                {
                    Login = "sensor-001",
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
                Size = 123456
            };
        }

        public static SensorWriteContract GetSensorWriteContract()
        {
            return new SensorWriteContract
            {
                Title = "Test Sensor",
                Mac = "00:00:00:00:00:01",
                Note = "Test note",
                X = 10.0f,
                Y = 20.0f,
                Battery = 99.9f,
                SectorId = 1,
                AreaId = 2,
                ExternalId = "ext-001",
                Login = "test-sensor"
            };
        }

        public static object GetAddSensorResponse()
        {
            return new[]
            {
                new
                {
                    Id = 1,
                    Title = "Test Sensor",
                    Mac = "00:00:00:00:00:01",
                    Note = "Test note",
                    X = 10.0,
                    Y = 20.0,
                    Battery = 99,
                    SectorId = 1,
                    AreaId = 2,
                    Login = "test-sensor"
                }
            };
        }
    }
}
