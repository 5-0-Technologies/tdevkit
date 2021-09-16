using Core.Enum;
using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Enum;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private static DevkitConnectorV3 devkitConnector;
        private static WireMockServer server;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url(URL)
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
        public async Task Devices1()
        {
            DeviceContract[] device = await devkitConnector.GetDevices();
            Assert.IsNotNull(device[0]);
        }

        [TestMethod]
        public async Task Devices2()
        {
            DeviceContract device1 = await devkitConnector.GetDevice(3);
            DeviceContract device2 = null;
            try
            {
                device2 = await devkitConnector.GetDevice(1);
            }
            catch (NotFoundException exception) { }
            Assert.IsNotNull(device1);
            Assert.IsNull(device2);
        }

        [TestMethod]
        public async Task Devices3()
        {
            DeviceContract device1 = await devkitConnector.GetDevice("RTU1");
            DeviceContract device2 = null;
            try
            {
                device2 = await devkitConnector.GetDevice("sdk-device2");
            }
            catch (NotFoundException exception) { }
            Assert.IsNotNull(device1);
            Assert.IsNull(device2);
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
        public async Task Devices6()
        {
            DeviceContract device = await devkitConnector.AddDevice(TestData.GetDevice());
            DeviceContract device2 = null;
            try
            {
                device2 = await devkitConnector.AddDevice(TestData.GetDevice());
            }
            catch (BadRequestException exception)
            {
                Assert.IsNull(null);
            }
            Assert.IsNotNull(device);
            Assert.IsNull(device2);
            await devkitConnector.DeleteDevice(device.Id);

            try
            {
                device2 = await devkitConnector.GetDevice(device.Id);
            }
            catch (NotFoundException exception) { }
            Assert.IsNull(device2);
        }

        [TestMethod]
        public async Task Devices7()
        {

            DeviceContract deviceData = TestData.GetDevice();

            DeviceContract device = await devkitConnector.AddDevice(deviceData);
            device.X = 20;
            device.Position = true;
            device.Note = "aaa";
            try
            {
                var message = await devkitConnector.UpdateDevice(device);
                var temp = 0;
            }
            catch (BadRequestException exception)
            {
                Assert.IsNotNull(null);
            }
            Assert.IsNotNull(device);
            await devkitConnector.DeleteDevice(device.Id);
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

            server.Given(Request.Create().WithPath("/v3/devices/man-down/batch").UsingPost())
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
