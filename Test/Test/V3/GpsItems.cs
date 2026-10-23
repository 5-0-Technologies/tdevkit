using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class GpsItems : Requests
    {
        const string GPS_ITEMS = "gps-items";

        [TestCategory("GpsItem")]
        [TestMethod]
        public async Task GetGpsItems_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails { Title = "GpsItems error", Detail = "Failed." };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + GPS_ITEMS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetGpsItems());
        }

        [TestCategory("GpsItem")]
        [TestMethod]
        public async Task GetGpsItems_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + GPS_ITEMS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { new GpsItemContract { Id = 1 } }));

            var response = await devkitConnector.GetGpsItems();
            Assert.IsInstanceOfType(response, typeof(GpsItemContract[]));
        }

        [TestCategory("GpsItem")]
        [TestMethod]
        public async Task GetGpsItem_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + GPS_ITEMS + "/" + Id).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new GpsItemContract { Id = Id }));

            var response = await devkitConnector.GetGpsItem(Id);
            Assert.IsInstanceOfType(response, typeof(GpsItemContract));
        }

        [TestCategory("GpsItem")]
        [TestMethod]
        public async Task AddGpsItem_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + GPS_ITEMS + "/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new GpsItemContract { Id = 1 }));

            var response = await devkitConnector.AddGpsItem(new GpsItemWriteContract { SectorId = 1 });
            Assert.IsInstanceOfType(response, typeof(GpsItemContract));
        }

        [TestCategory("GpsItem")]
        [TestMethod]
        public async Task UpdateGpsItem_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + GPS_ITEMS + "/" + Id).UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateGpsItem(Id, new { X = 1f });
        }

        [TestCategory("GpsItem")]
        [TestMethod]
        public async Task DeleteGpsItem_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + GPS_ITEMS + "/" + Id).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteGpsItem(Id);
        }
    }
}
