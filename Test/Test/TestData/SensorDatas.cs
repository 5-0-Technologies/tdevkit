using SDK.Models;
using System;

namespace Test.TestData
{
    public static class SensorDatas
    {
        public static SensorDataContract GetSensorData()
        {
            return new SensorDataContract
            {
                Id = 1,
                SensorId = 1,
                Quantity = "temperature",
                Value = "25.5",
                Unit = "°C",
                DataType = SDK.Enum.SensorDataType.Decimal,
                Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
        }

        public static SensorDataContract[] GetSensorDatas()
        {
            return new SensorDataContract[]
            {
                new SensorDataContract
                {
                    Id = 1,
                    SensorId = 1,
                    Quantity = "temperature",
                    Value = "25.5",
                    Unit = "°C",
                    DataType = SDK.Enum.SensorDataType.Decimal,
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                },
                new SensorDataContract
                {
                    Id = 2,
                    SensorId = 1,
                    Quantity = "humidity",
                    Value = "60",
                    Unit = "%",
                    DataType = SDK.Enum.SensorDataType.Decimal,
                    Timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds()
                }
            };
        }
    }
} 