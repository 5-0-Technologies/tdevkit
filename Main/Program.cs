using SDK.Communication;
using SDK.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using tDevkit;

namespace Main
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string ClientName = "{insert}";
            const string ClientGuid = "{insert}";
            const string BranchGuid = "{insert}";
            const string ApiKey = "{insert}";
            const string Login = "{insert}";
            const string Password = "{insert}";

            try
            {
                // Define connection options with specific credentials and client identifiers
                ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
                ConnectionOptions connectionOptions = optionsBuilder
                    .Url("https://twin.rtls.solutions/api/")
                    .Client(ClientName)
                    .ClientGuid(ClientGuid)
                    .BranchGuid(BranchGuid)
                    .Timeout(1000)
                    .ApiKey(ApiKey)
                    .Version(ConnectionOptions.VERSION_3)
                    .Login(Login)
                    .Password(Password)
                    .Build();

                // Create tDevKit connector class instance and authorize by credentials in builder
                DevkitConnectorV3 devkitConnector = (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);
                AuthenticationResponseContract auth = await devkitConnector.Authenticate(false);
                Console.WriteLine(auth);

                // Define sensors data list of SensorDataContract
                var dataList = new[]
                {
                    new SensorDataContract
                    {
                        Quantity = "Voltage",
                        Value = "120",
                        Unit = "V",
                        DataType = "Single"
                    },
                    new SensorDataContract
                    {
                        Quantity = "Frequency",
                        Value = "1",
                        Unit = "Hz",
                        DataType = "Single"
                    },
                    new SensorDataContract
                    {
                        Quantity = "OK parts",
                        Value = "600",
                        Unit = "pcs",
                        DataType = "Int32"
                    }
                };

                // Create sensor contract with specific data
                SensorContract sensor = new SensorContract
                {
                    Login = "buffer",
                    SensorData = dataList.ToArray(),
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
}
