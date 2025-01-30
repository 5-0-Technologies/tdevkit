using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using System;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Paths : Requests
    {
        const string PATHS = "paths";

        [TestCategory("Path")]
        [TestMethod]
        public async Task GetPaths_ShouldReturnPaths()
        {
            var bodyContent = TestData.Paths.GetTestPaths();

            server.Given(Request.Create().WithPath(PATH_BASE + PATHS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.GetPaths();

            Assert.IsInstanceOfType(response, typeof(PathContract[]));
        }

        [TestCategory("Path")]
        [TestMethod]
        public async Task GetPath_ShouldReturnPath()
        {
            const int pathId = 1;
            var bodyContent = TestData.Paths.GetTestPath(TestData.Paths.TestPathId1);

            server.Given(Request.Create().WithPath(PATH_BASE + PATHS + "/" + pathId).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                .WithBodyAsJson(bodyContent));

            var response = await devkitConnector.GetPath(pathId);
            Assert.IsInstanceOfType(response, typeof(PathContract));
        }
    }
}
