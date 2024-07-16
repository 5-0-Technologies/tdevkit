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
            var bodyContent = new AreaContract()
            {
                Id = 1,
                BranchId = 1,
                Guid = Guid.NewGuid(),
                Title = "area1",
                Description = "description",
                SectorId = 1,
                LayerId = 1,
            };

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AreaContract[] { bodyContent }));

            AreaContract[] response = await devkitConnector.GetAreas();

            Assert.IsInstanceOfType(response, typeof(AreaContract[]));
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task GetArea_ShouldReturnArea()
        {
            const int Id = 1;
            var bodyContent = new AreaContract()
            {
                Id = 1,
                BranchId = 1,
                Guid = Guid.NewGuid(),
                Title = "area1",
                Description = "description",
                SectorId = 1,
                LayerId = 1,
            };

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            AreaContract response = await devkitConnector.GetArea(1);
            Assert.IsInstanceOfType(response, typeof(AreaContract));
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task AddArea_ShouldReturnArea()
        {
            var bodyContent = new AreaContract()
            {
                Id = 1,
                BranchId = 1,
                Guid = Guid.NewGuid(),
                Title = "area1",
                Description = "description",
                SectorId = 1,
                LayerId = 1,
            };

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            AreaContract response = await devkitConnector.AddArea(bodyContent);
            Assert.IsInstanceOfType(response, typeof(AreaContract));
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task UpdateArea_ShouldReturn200()
        {
            var bodyContent = new AreaContract()
            {
                Id = 1,
                BranchId = 1,
                Guid = Guid.NewGuid(),
                Title = "area1",
                Description = "description",
                SectorId = 1,
                LayerId = 1,
            };

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS + "/" + bodyContent.Id).UsingPatch())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            await devkitConnector.UpdateArea(bodyContent);
            Assert.IsTrue(true);
        }

        [TestCategory("Area")]
        [TestMethod]
        public async Task DeleteArea_ShouldReturn200()
        {
            const int Id = 1;
            var bodyContent = new AreaContract()
            {
                Id = 1,
                BranchId = 1,
                Guid = Guid.NewGuid(),
                Title = "area1",
                Description = "description",
                SectorId = 1,
                LayerId = 1,
            };

            server.Given(Request.Create().WithPath(PATH_BASE + AREAS + "/" + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            await devkitConnector.DeleteArea(Id);
            Assert.IsTrue(true);
        }
    }
}
