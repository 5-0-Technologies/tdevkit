using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class SensorDatas : Requests
    {
        const string SENSOR_DATAS = "sensor-datas";

        [TestCategory("SensorData")]
        [TestMethod]
        public async Task GetSensorDatas_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Sensor data error",
                Detail = "Failed to retrieve sensor data."
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SENSOR_DATAS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetSensorDatas());
        }

        [TestCategory("SensorData")]
        [TestMethod]
        public async Task GetSensorDatas_GetAllSensorDatas_ShouldReturn200()
        {
            var bodyContent = TestData.SensorDatas.GetSensorDatas();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SENSOR_DATAS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            SensorDataContract[] response = await devkitConnector.GetSensorDatas();

            Assert.IsInstanceOfType(response, typeof(SensorDataContract[]));
        }

        [TestCategory("SensorData")]
        [TestMethod]
        public async Task GetSensorData_GetSensorDataById_ShouldReturn200()
        {
            const int Id = 3;
            var bodyContent = TestData.SensorDatas.GetSensorData();

            server.Given(Request.Create().WithPath(PATH_BASE + SENSOR_DATAS + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            SensorDataContract response = await devkitConnector.GetSensorData(Id);

            Assert.IsInstanceOfType(response, typeof(SensorDataContract));
        }

        [TestCategory("SensorData")]
        [TestMethod]
        public async Task AddSensorData_AddSensorData_ShouldReturn200()
        {
            var bodyContent = TestData.SensorDatas.GetSensorData();

            server.Given(Request.Create().WithPath(PATH_BASE + SENSOR_DATAS).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.AddSensorData(bodyContent);

            Assert.IsInstanceOfType(response, typeof(PostResponseContract));
        }

        [TestCategory("SensorData")]
        [TestMethod]
        public async Task UpdateSensorData_UpdateSensorData_ShouldReturn200()
        {
            const int Id = 1;
            var changes = new { Value = "Updated Value" };

            server.Given(Request.Create().WithPath(PATH_BASE + SENSOR_DATAS + "/" + Id).UsingPatch())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateSensorData(Id, changes);
        }

        [TestCategory("SensorData")]
        [TestMethod]
        public async Task DeleteSensorData_DeleteSensorData_ShouldReturn200()
        {
            const int Id = 1;

            server.Given(Request.Create().WithPath(PATH_BASE + SENSOR_DATAS + "/" + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteSensorData(Id);
        }
    }
} 