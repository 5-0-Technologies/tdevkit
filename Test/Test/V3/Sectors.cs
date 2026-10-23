using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Sectors : Requests
    {
        const string SECTORS = "sectors";

        [TestCategory("Sector")]
        [TestMethod]
        public async Task GetSectors_ShouldReturn200()
        {
            var bodyContent = TestData.Sectors.GetSector();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SectorContract[] { bodyContent }));

            SectorContract[] response = await devkitConnector.GetSectors();
            Assert.IsInstanceOfType(response, typeof(SectorContract[]));
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task GetSector_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS + "/" + Id).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Sectors.GetSector()));

            var response = await devkitConnector.GetSector(Id);
            Assert.IsInstanceOfType(response, typeof(SectorContract));
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task AddSector_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS).UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Sectors.GetSector()));

            var response = await devkitConnector.AddSector(new SectorWriteContract { Title = "s" });
            Assert.IsInstanceOfType(response, typeof(SectorContract));
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task UpdateSector_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS + "/" + Id).UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateSector(Id, new { Title = "u" });
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task DeleteSector_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS + "/" + Id).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteSector(Id);
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task GetSectorLayout_ShouldReturn200()
        {
            const int Id = 1;
            var bytes = new byte[] { 1, 2 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS + "/layout/" + Id).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetSectorLayout(Id);
            CollectionAssert.AreEqual(bytes, response);
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task GetSectorLayouts_ShouldReturn200()
        {
            var bytes = new byte[] { 3 };
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS + "/layouts/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBody(bytes));

            var response = await devkitConnector.GetSectorLayouts();
            CollectionAssert.AreEqual(bytes, response);
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task PostSectorLayout_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS + "/layout/" + Id + "/png").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PostSectorLayout(Id, "png", new byte[] { 1 });
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task PutSectorLayout_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS + "/" + Id + "/layout").UsingPut())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.PutSectorLayout(Id, new byte[] { 1 });
        }

        [TestCategory("Sector")]
        [TestMethod]
        public async Task DeleteSectorLayout_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS + "/" + Id + "/layout").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteSectorLayout(Id);
        }
    }
}
