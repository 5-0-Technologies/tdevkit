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
    public class Lookups : Requests
    {
        const string LOOKUPS = "lookups";

        [TestCategory("Lookup")]
        [TestMethod]
        public async Task GetLookups_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails { Title = "Lookups error", Detail = "Failed." };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOOKUPS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetLookups());
        }

        [TestCategory("Lookup")]
        [TestMethod]
        public async Task GetLookups_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOOKUPS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { new LookupContract { Id = 1 } }));

            var response = await devkitConnector.GetLookups();
            Assert.IsInstanceOfType(response, typeof(LookupContract[]));
        }

        [TestCategory("Lookup")]
        [TestMethod]
        public async Task GetLookup_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOOKUPS + "/" + Id).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new LookupContract { Id = Id }));

            var response = await devkitConnector.GetLookup(Id);
            Assert.IsInstanceOfType(response, typeof(LookupContract));
        }

        [TestCategory("Lookup")]
        [TestMethod]
        public async Task AddLookup_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOOKUPS + "/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new LookupContract { Id = 1 }));

            var response = await devkitConnector.AddLookup(new LookupWriteContract { Title = "t" });
            Assert.IsInstanceOfType(response, typeof(LookupContract));
        }

        [TestCategory("Lookup")]
        [TestMethod]
        public async Task UpdateLookup_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOOKUPS + "/" + Id).UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateLookup(Id, new { Title = "u" });
        }

        [TestCategory("Lookup")]
        [TestMethod]
        public async Task DeleteLookup_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOOKUPS + "/" + Id).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteLookup(Id);
        }
    }
}
