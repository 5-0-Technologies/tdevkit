using SDK.Enum;
using SDK.Models;

namespace Test.TestData
{
    public static class Sensors
    {
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
    }
}
