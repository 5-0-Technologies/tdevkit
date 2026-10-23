using Core.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Enum;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Devices : Requests
    {
        const string DEVICES = "devices";

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDevices_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Specify the Error from Type property more.",
                Detail = "How to solve error."
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
            var bodyContent = TestData.Devices.GetDevices();

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
            var bodyContent = TestData.Devices.GetDevice();

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
            var bodyContent = TestData.Devices.GetDevice();

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
            var bodyContent = TestData.Devices.GetDevice();

            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            DeviceContract response = await devkitConnector.AddDevice((DeviceWriteContract)bodyContent);

            Assert.IsInstanceOfType(response, typeof(DeviceContract));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task DeleteDevice_DeleteDevice_ShouldReturn200()
        {

            const int Id = 1;

            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/" + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteDevice(Id);
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task ManDown()
        {
            const string device = "Device1";
            const long ts = 1000;
            var bodyContent = TestData.Devices.GetManDownDataContract();

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
            var bodyContent = TestData.Devices.GetManDownDataContracts();

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

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDynamicDevices_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/dynamic-locations").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new DynamicDeviceContract[0]));

            var response = await devkitConnector.GetDynamicDevices();
            Assert.IsInstanceOfType(response, typeof(DynamicDeviceContract[]));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDynamicDevicesShort_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/dynamic-locations-short").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new DynamicDeviceShortContract[0]));

            var response = await devkitConnector.GetDynamicDevicesShort();
            Assert.IsInstanceOfType(response, typeof(DynamicDeviceShortContract[]));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task UpdateDevice_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/" + Id).UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateDevice(Id, new { Title = "u" });
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task ManDownBatch_ManDownBatchContract_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/man-down/batch").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Devices.GetManDownDataContracts()));

            var response = await devkitConnector.ManDownBatch(new[]
            {
                new ManDownBatchContract { Login = "Device1", Timestamp = 1000, FallType = FallType.ManDown }
            });
            Assert.IsInstanceOfType(response, typeof(ManDownResponseContract[]));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task RegisterDevice_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/register/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.RegisterDevice(new DeviceRegistrationContract { Login = "d1" });
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDeviceLocations_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + DEVICES + "/locations/")
                    .WithParam("deviceId", "1")
                    .WithParam("from", "10")
                    .WithParam("to", "20")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SimpleLocationContract[0]));

            var response = await devkitConnector.GetDeviceLocations(1, 10, 20);
            Assert.IsInstanceOfType(response, typeof(SimpleLocationContract[]));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task DeviceHeartbeat_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/heartbeat/").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeviceHeartbeat();
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task UpdateDeviceStatus_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/device-status/").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateDeviceStatus(new DeviceStatusContract { Battery = 50 });
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task PostDeviceEvent_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/event/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PostDeviceEvent(new EventContract { EventType = "e" });
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDeviceHeatmap_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + DEVICES + "/heatmap")
                    .WithParam("start", "1")
                    .WithParam("stop", "2")
                    .WithParam("deviceIds", "10", "20")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new HeatmapContract[0]));

            var response = await devkitConnector.GetDeviceHeatmap(1, 2, new[] { 10, 20 });
            Assert.IsInstanceOfType(response, typeof(HeatmapContract[]));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDeviceApk_ShouldReturn200()
        {
            var bytes = new byte[] { 1, 2 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/apk/code1").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetDeviceApk("code1");
            CollectionAssert.AreEqual(bytes, response);
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDeviceVersion_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/version/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson("1.0.0"));

            var response = await devkitConnector.GetDeviceVersion();
            Assert.AreEqual("1.0.0", response);
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task PostDeviceVersion_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/version/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PostDeviceVersion(new { version = "1.0.0" });
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetTConnectVersions_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/versions/tConnect/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { "1.0" }));

            var response = await devkitConnector.GetTConnectVersions();
            Assert.IsInstanceOfType(response, typeof(string[]));
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task GetDeviceVersion_ByLogin_ShouldReturn200()
        {
            const string Login = "d1";
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/" + Login + "/version").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson("2.0.0"));

            var response = await devkitConnector.GetDeviceVersion(Login);
            Assert.AreEqual("2.0.0", response);
        }

        [TestCategory("Device")]
        [TestMethod]
        public async Task PostDeviceVersion_ByLogin_ShouldReturn200()
        {
            const string Login = "d1";
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DEVICES + "/" + Login + "/version").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PostDeviceVersion(Login, new { version = "2.0.0" });
        }
    }
}

