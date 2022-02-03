using Core.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Enum;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Test.V3
{
    [TestClass]
    public class DevicesTest
    {
        const string URL = "http://localhost:8000";
        const string PATH_BASE = "/api/v3/devices";
        static WireMockServer server;
        static DevkitConnectorV3 devkitConnector;

        protected static WireMockServer Server { get => server; set => server = value; }

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url(URL + "/api")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("X1fprPtlkvolW1Bl47UQV4SoW8siY3n8QDQkDsGJ")
                .Version(ConnectionOptions.VERSION_3)
                .Build();
            devkitConnector = (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);

            server = WireMockServer.Start(new WireMockServerSettings()
            {
                Urls = new[] { URL }
            });
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            server.Stop();
        }

        [TestMethod]
        public async Task GetDevices_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ExceptionContent
            {
                Code = "10",
                Message = "Error"
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetDevices());
        }

        [TestMethod]
        public async Task GetDevice_GetAllDevices_ShouldReturn200()
        {
            var bodyContent = new DeviceContract[] {
                new DeviceContract(){}
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract[] response = await devkitConnector.GetDevices();

            Assert.IsInstanceOfType(response, typeof(DeviceContract[]));
        }

        [TestMethod]
        public async Task GetDevice_GetDeviceById_ShouldReturn200()
        {
            const int Id = 3;
            var bodyContent = new DeviceContract()
            {
                Id = Id
            };

            server.Given(Request.Create().WithPath(PATH_BASE + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract response = await devkitConnector.GetDevice(Id);

            Assert.IsInstanceOfType(response, typeof(DeviceContract));
        }

        [TestMethod]
        public async Task GetDevice_GetDeviceByLogin_ShouldReturn200()
        {
            const string Login = "login";
            var bodyContent = new DeviceContract()
            {
                Login = Login
            };

            server.Given(Request.Create().WithPath(PATH_BASE + "/login/" + Login).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract response = await devkitConnector.GetDevice(Login);

            Assert.IsInstanceOfType(response, typeof(DeviceContract));
        }

        [TestMethod]
        public async Task AddDevice_AddDevice_ShouldReturn200()
        {
            const string Login = "login";
            var bodyContent = new DeviceContract()
            {
                Login = Login
            };

            server.Given(Request.Create().WithPath(PATH_BASE).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract response = await devkitConnector.AddDevice(bodyContent);

            Assert.IsInstanceOfType(response, typeof(DeviceContract));
        }

        [TestMethod]
        public async Task DeleteDevice_DeleteDevice_ShouldReturn200()
        {

            const int Id = 1;
            var bodyContent = new DeviceContract()
            {
                Id = Id
            };

            server.Given(Request.Create().WithPath(PATH_BASE + "/" + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            await devkitConnector.DeleteDevice(Id);
        }

        [TestMethod]
        public async Task ManDown()
        {
            const string PATH = PATH_BASE + "/man-down";
            const string device = "Device1";
            const long ts = 1000;
            var bodyContent = new ManDownResponseContract()
            {
                Login = device,
                Timestamp = ts,
                Action = ActionType.Create,
                Success = true
            };

            server.Given(Request.Create().WithPath(PATH).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.ManDown(new ManDownContract
            {
                Login = device,
                Timestamp = ts,
                FallType = FallType.ManDown
            });

            Assert.IsInstanceOfType(response, typeof(ManDownResponseContract));
        }

        [TestMethod]
        public async Task ManDownBatch()
        {
            const string PATH = PATH_BASE + "/man-down/batch";
            const string device = "Device1";
            const long ts = 1000;
            var bodyContent = new ManDownResponseContract[] {
                new ManDownResponseContract()
                {
                    Login = device,
                    Timestamp = ts,
                    Action = ActionType.Create,
                    Success = true
                }
            };

            server.Given(Request.Create().WithPath(PATH).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.ManDownBatch(new ManDownContract[] {
                new ManDownContract()
                {
                    Login = device,
                    Timestamp = ts,
                    FallType = FallType.ManDown
                }
            });

            Assert.IsInstanceOfType(response, typeof(ManDownResponseContract[]));
        }
    }
}
