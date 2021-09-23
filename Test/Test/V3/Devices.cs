using Core.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Enum;
using SDK.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using tDevkit;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Test
{
    //(8/9)
    [TestClass]
    public class DeviceTest
    {
        private const string URL = "http://localhost:8000";
        private const string PATH_BASE = "/api/v3/devices";
        private static DevkitConnectorV3 devkitConnector;
        private static WireMockServer server;

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
        public async Task GetDevice_GetAllDevices_ShouldReturn200()
        {
            var bodyContent = new DeviceContract[] {
                new DeviceContract(){}
            };

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

            server.Given(Request.Create().WithPath(PATH_BASE + Id).UsingGet())
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

            server.Given(Request.Create().WithPath(PATH_BASE + "login/" + Login).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract response = await devkitConnector.GetDevice(Login);

            Assert.IsInstanceOfType(response, typeof(DeviceContract));
        }

        //[TestMethod]
        //public async Task Devices4()
        //{
        //    DynamicDeviceContract[] device = await devkitConnector.GetDynamicDevices();
        //    Assert.IsNotNull(device[0]);
        //}

        //[TestMethod]
        //public async Task Devices5()
        //{
        //    DynamicDeviceContract[] device = await devkitConnector.GetDynamicDevicesShort();
        //    Assert.IsNotNull(device[0]);
        //}

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

            server.Given(Request.Create().WithPath(PATH_BASE + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.DeleteDevice(Id);

            Assert.IsInstanceOfType(response, typeof(HttpResponseMessage));
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Devices8()
        {
            //Delete je otestovany v add a update
        }

        [TestMethod]
        public async Task Devices9()
        {
            //Register
        }

        [TestMethod]
        public async Task ManDownBatch()
        {
            const string PATH = PATH_BASE + "man-down/batch";
            const string device = "Device1";
            const long ts = 1000;
            var bodyContent = new ManDownBatchResponseContract[] {
                new ManDownBatchResponseContract()
                {
                    Login = device,
                    Timestamp = ts,
                    Action = ActionType.Create,
                    Success = true
                }
            };

            server.Given(Request.Create().WithPath(PATH).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.ManDownBatch(new ManDownBatchContract[] {
                new ManDownBatchContract()
                {
                    Login = device,
                    Timestamp = ts,
                    FallType = FallType.ManDown
                }
            });

            Assert.IsInstanceOfType(response, typeof(ManDownBatchContract[]));
        }
    }
}
