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
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url("https://api.platform.twinzo.com/")
                .ClientGuid(ClientGuid)
                .BranchGuid(BranchGuid)
                .Timeout(1000)
                .ApiKey(ApiKey)
                .Version(ConnectionOptions.VERSION_5)
                .Build();

            DevkitConnectorV5 devkitConnector = (DevkitConnectorV5)DevkitFactory.CreateDevkitConnector(connectionOptions);

            var dataList = new[]
            {
                    new SensorDataBatchContract
                    {
                        Quantity = "Voltage",
                        Value = "120",
                        Unit = "V",
                        DataType = "Decimal",
                    },
                    new SensorDataBatchContract
                    {
                        Quantity = "Frequency",
                        Value = "1",
                        Unit = "Hz",
                        DataType = "Decimal",
                    },
                    new SensorDataBatchContract
                    {
                        Quantity = "OK parts",
                        Value = "600",
                        Unit = "pcs",
                        DataType = "Int32",
                    }
                };

            SensorBatchContract sensor = new SensorBatchContract
            {
                Login = "buffer",
                Title = "Buffer Sensor",
                SensorData = dataList
            };

            SensorResponseContract[] response = await devkitConnector.AddSensorData(new[] { sensor });
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
