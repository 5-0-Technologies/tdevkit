using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Sensors : Requests
    {
        const string SENSORS = "sensors";

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task GetSensors_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Specify the Error from Type property more.",
                Detail = "How to solve error."
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetSensors());
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task GetSensors_GetAllSensors_ShouldReturn200()
        {
            var bodyContent = TestData.Sensors.GetSensors();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            SensorContract[] response = await devkitConnector.GetSensors();

            Assert.IsInstanceOfType(response, typeof(SensorContract[]));
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task GetSensor_GetSensorById_ShouldReturn200()
        {
            const int Id = 3;
            var bodyContent = TestData.Sensors.GetSensor();

            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            SensorContract response = await devkitConnector.GetSensor(Id);

            Assert.IsInstanceOfType(response, typeof(SensorContract));
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task GetSensor_GetSensorByLogin_ShouldReturn200()
        {
            const string Login = "sensor-login";
            var bodyContent = TestData.Sensors.GetSensor();

            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS + "/login/" + Login).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            SensorContract response = await devkitConnector.GetSensor(Login);

            Assert.IsInstanceOfType(response, typeof(SensorContract));
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task UpdateSensor_UpdateSensor_ShouldReturn200()
        {
            const int Id = 1;
            var changes = new { Title = "Updated Sensor" };

            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS + "/" + Id).UsingPatch())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateSensor(Id, changes);
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task DeleteSensor_DeleteSensor_ShouldReturn200()
        {
            const int Id = 1;

            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS + "/" + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteSensor(Id);
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task AddSensorData_AddSensorDataBatch_ShouldReturn200()
        {
            var bodyContent = TestData.Sensors.GetSensorDataBatch();

            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS + "/batch").UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.AddSensorData(TestData.Sensors.GetSensorBatchContracts());

            Assert.IsInstanceOfType(response, typeof(SensorResponseContract[]));
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task AddSensorData_AddSensorData_ShouldReturn200()
        {
            var bodyContent = TestData.Sensors.GetSensorData();

            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS + "/sensor-data").UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.AddSensorData(TestData.Sensors.GetSensorDataBatchContracts());

            Assert.IsInstanceOfType(response, typeof(SensorDataResponseContract[]));
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task GetSensorAppInfo_GetSensorAppInfo_ShouldReturn200()
        {
            var bodyContent = TestData.Sensors.GetSensorAppInfo();

            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS + "/app-info").UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.GetSensorAppInfo();

            Assert.IsInstanceOfType(response, typeof(SensorAppInfoContract));
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task AddSensor_AddSensor_ShouldReturn200()
        {
            var bodyContent = TestData.Sensors.GetAddSensorResponse();
            var sensorWriteContract = TestData.Sensors.GetSensorWriteContract();

            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            SensorResponseContract[] response = await devkitConnector.AddSensor(sensorWriteContract);

            Assert.IsInstanceOfType(response, typeof(SensorResponseContract[]));
            Assert.AreEqual(1, response.Length);
            Assert.AreEqual("sensor-login", response[0].Login);
            Assert.IsTrue(response[0].Success);
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task AddSensor_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Specify the Error from Type property more.",
                Detail = "How to solve error."
            };
            var sensorWriteContract = TestData.Sensors.GetSensorWriteContract();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.AddSensor(sensorWriteContract));
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task GetSensorQuantities_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + SENSORS + "/sensor-data")
                    .WithParam("sensorId", "1")
                    .WithParam("start", "10")
                    .WithParam("stop", "20")
                    .WithParam("aggregation", "mean")
                    .WithParam("quantities", "temp/1")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SensorQuantityContract[0]));

            var response = await devkitConnector.GetSensorQuantities(1, 10, 20, new[] { "temp/1" });
            Assert.IsInstanceOfType(response, typeof(SensorQuantityContract[]));
        }

        [TestCategory("Sensor")]
        [TestMethod]
        public async Task GetSensorAppFile_ShouldReturn200()
        {
            var bytes = new byte[] { 9, 9 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SENSORS + "/app-file").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetSensorAppFile();
            CollectionAssert.AreEqual(bytes, response);
        }
    }
}

