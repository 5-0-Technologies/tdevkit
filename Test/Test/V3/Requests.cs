using Core.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Enum;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Test.V3
{
    [TestClass]
    public class Requests
    {
        const string URL = "http://localhost:8000";
        const string PATH_BASE = "/api/v3/";

        const string ACCOUNT = "account";
        const string CONFIGURATION = "configuration";
        const string DEVICES = "devices";
        const string LAYERS = "layers";
        const string SECTORS = "sectors";

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
            server.Dispose();
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
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetDevices());
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDevice_GetAllDevices_ShouldReturn200()
        {
            var bodyContent = new DeviceContract[] {
                new DeviceContract(){}
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract[] response = await devkitConnector.GetDevices();

            Assert.IsInstanceOfType(response, typeof(DeviceContract[]));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDevice_GetDeviceById_ShouldReturn200()
        {
            const int Id = 3;
            var bodyContent = new DeviceContract()
            {
                Id = Id
            };

            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract response = await devkitConnector.GetDevice(Id);

            Assert.IsInstanceOfType(response, typeof(DeviceContract));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDevice_GetDeviceByLogin_ShouldReturn200()
        {
            const string Login = "login";
            var bodyContent = new DeviceContract()
            {
                Login = Login
            };

            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/login/" + Login).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract response = await devkitConnector.GetDevice(Login);

            Assert.IsInstanceOfType(response, typeof(DeviceContract));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task AddDevice_AddDevice_ShouldReturn200()
        {
            const string Login = "login";
            var bodyContent = new DeviceContract()
            {
                Login = Login
            };

            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract response = await devkitConnector.AddDevice(bodyContent);

            Assert.IsInstanceOfType(response, typeof(DeviceContract));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task DeleteDevice_DeleteDevice_ShouldReturn200()
        {

            const int Id = 1;
            var bodyContent = new DeviceContract()
            {
                Id = Id
            };

            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/" + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            await devkitConnector.DeleteDevice(Id);
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task ManDown()
        {
            const string device = "Device1";
            const long ts = 1000;
            var bodyContent = new ManDownResponseContract()
            {
                Login = device,
                Timestamp = ts,
                Action = ActionType.Create,
                Success = true
            };

            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/man-down").UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.ManDown(new ManDownContract
            {
                Login = device,
                Timestamp = ts,
                FallType = FallType.ManDown
            });

            Assert.IsInstanceOfType(response, typeof(ManDownResponseContract));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task ManDownBatch()
        {
            const string PATH = PATH_BASE + DEVICES + "/man-down/batch";
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

        [TestCategory("Layer")]
        [TestMethod]
        public async Task GetLocalizationLayers_ShouldReturnLayers()
        {
            var bodyContent = new LoginContract()
            {
                Login = "login"
            };

            server.Given(Request.Create().WithPath(PATH_BASE + LAYERS + "/localization").UsingPost())
                .RespondWith(
                    Response.Create()
                    .WithStatusCode(200)
                    .WithBodyAsJson(new LayerContract[] {
                        new LayerContract(){
                            Id = 1,
                        }
                    })
            );

            var response = await devkitConnector.GetLocalizationLayers(bodyContent);

            Assert.IsInstanceOfType(response, typeof(LayerContract[]));
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task GetSector_GetDeviceByLogin_ShouldReturn200()
        {
            var bodyContent = new SectorContract()
            {
                Id = 1,
                Guid = Guid.NewGuid(),
            };

            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SectorContract[] { bodyContent }));

            SectorContract[] response = await devkitConnector.GetSectors();

            Assert.IsInstanceOfType(response, typeof(SectorContract[]));
        }


        [TestCategory("GetAccountConfiguration")]
        [TestMethod]
        public async Task GetAccountConfiguration_ShouldReturnDeviceConfiguration_WhenDeviceAndConfigurationExists()
        {
            const string deviceLogin = "deviceLogin";
            const string configKey = "configKey";

            server.Given(Request.Create().WithPath(PATH_BASE + CONFIGURATION + $"/{ACCOUNT}/{deviceLogin}/{configKey}").UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson("{\"test\": \"test\"}"));

            var response = await devkitConnector.GetAccountConfiguration(deviceLogin, configKey);

            Assert.IsInstanceOfType(response, typeof(JsonDocument));
        }
    }
}
