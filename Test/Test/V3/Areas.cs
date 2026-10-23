using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using System;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Areas : Requests
    {
        const string AREAS = "areas";

        [TestCategory("Area")]
        [TestMethod]
        public async Task GetAreas_ShouldReturnAreas()
        {
            var bodyContent = TestData.Areas.GetArea();

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AreaContract[] { bodyContent }));

            AreaContract[] response = await devkitConnector.GetAreas();

            Assert.IsInstanceOfType(response, typeof(AreaContract[]));
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task GetArea_ShouldReturnArea()
        {
            server.Given(Request.Create().WithPath(PATH_BASE + AREAS + "/1").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                .WithBodyAsJson(TestData.Areas.GetArea()));

            var response = await devkitConnector.GetArea(1);
            Assert.IsInstanceOfType(response, typeof(AreaContract));
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task AddArea_ShouldReturnArea()
        {
            var bodyContent = TestData.Areas.GetArea();

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            AreaContract response = await devkitConnector.AddArea((AreaWriteContract)bodyContent);
            Assert.IsInstanceOfType(response, typeof(AreaContract));
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task UpdateArea_ShouldReturn200()
        {
            var bodyContent = TestData.Areas.GetArea();

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS + "/" + bodyContent.Id).UsingPatch())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            await devkitConnector.UpdateArea(bodyContent.Id, bodyContent);
            Assert.IsTrue(true);
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task DeleteArea_ShouldReturn200()
        {
            const int Id = 1;

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS + "/" + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteArea(Id);
            Assert.IsTrue(true);
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task GetGridAreaOccurence_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + AREAS + "/grid-area-occurrence/")
                    .WithParam("deviceId", "1")
                    .WithParam("shiftId", "2")
                    .WithParam("start", "10")
                    .WithParam("stop", "20")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AreaOccurrence[0]));

            var response = await devkitConnector.GetGridAreaOccurence(1, 2, 10, 20);
            Assert.IsInstanceOfType(response, typeof(AreaOccurrence[]));
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task GetAreaImageInfo_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + AREAS + "/" + Id + "/image-info").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AreaImageInfoContract { AreaId = Id }));

            var response = await devkitConnector.GetAreaImageInfo(Id);
            Assert.IsInstanceOfType(response, typeof(AreaImageInfoContract));
        }
    }
}

