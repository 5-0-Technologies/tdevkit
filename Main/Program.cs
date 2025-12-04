using SDK;
using SDK.Communication;
using SDK.Enum;
using SDK.Models;
using System;
using System.Threading.Tasks;


internal class Program
{
    private static async Task Main(string[] args)
    {
        const string ClientGuid = "{client-guid}";
        const string BranchGuid = "{branch-guid}";
        const string ApiKey = "{api-token}";

        try
        {
            // Define connection options with specific credentials and client identifiers
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url("https://api.platform.twinzo.com/")
                .ClientGuid(ClientGuid)
                .BranchGuid(BranchGuid)
                .Timeout(1000)
                .ApiKey(ApiKey)
                .Version(ConnectionOptions.VERSION_3)
                .Build();

            // Create tDevKit connector class instance and authorize by credentials in builder
            DevkitConnectorV3 devkitConnector = (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);

            // Define sensors data list of SensorDataContract
            var dataList = new[]
            {
                    new SensorDataWriteContract
                    {
                        Quantity = "Voltage",
                        Value = "120",
                        Unit = "V",
                        DataType = SensorDataType.Decimal,
                        Index = 0,
                    },
                    new SensorDataWriteContract
                    {
                        Quantity = "Frequency",
                        Value = "1",
                        Unit = "Hz",
                        DataType = SensorDataType.Decimal,
                        Index = 0,
                    },
                    new SensorDataWriteContract
                    {
                        Quantity = "OK parts",
                        Value = "600",
                        Unit = "pcs",
                        DataType = SensorDataType.Int32,
                        Index = 0,
                    }
                };

            // Create sensor contract with specific data
            SensorWriteContract sensor = new SensorWriteContract
            {
                Login = "buffer",
                Title = "Buffer Sensor",
            };

            // Send sensor with specified data to Twinzo server
            PostResponseContract[] response = await devkitConnector.AddSensorData(new[] { sensor });
            Console.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}