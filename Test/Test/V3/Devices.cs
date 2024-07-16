﻿using Core.Enum;
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
                new DeviceContract(){ }
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
    }
}
