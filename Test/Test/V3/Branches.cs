using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using SDK.Exceptions;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Branches : Requests
    {
        const string BRANCHES = "branches";

        [TestCategory("Branch")]
        [TestMethod]
        public async Task GetBranches_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Branches error",
                Detail = "Failed to retrieve branches."
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + BRANCHES).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetBranches());
        }

        [TestCategory("Branch")]
        [TestMethod]
        public async Task GetBranches_GetAllBranches_ShouldReturn200()
        {
            var bodyContent = TestData.Branches.GetBranches();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + BRANCHES).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            BranchContract[] response = await devkitConnector.GetBranches();

            Assert.IsInstanceOfType(response, typeof(BranchContract[]));
        }

        [TestCategory("Branch")]
        [TestMethod]
        public async Task GetBranch_GetBranchById_ShouldReturn200()
        {
            const int Id = 1;
            var bodyContent = TestData.Branches.GetBranch();

            server.Given(Request.Create().WithPath(PATH_BASE + BRANCHES + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            BranchContract response = await devkitConnector.GetBranch(Id);

            Assert.IsInstanceOfType(response, typeof(BranchContract));
        }
    }
} 