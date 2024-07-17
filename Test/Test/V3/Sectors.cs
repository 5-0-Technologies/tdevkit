using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using System;
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
        public async Task GetSector_GetDeviceByLogin_ShouldReturn200()
        {
            var bodyContent = TestData.Sectors.GetSector();

            server.Given(Request.Create().WithPath(PATH_BASE + SECTORS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SectorContract[] { bodyContent }));

            SectorContract[] response = await devkitConnector.GetSectors();

            Assert.IsInstanceOfType(response, typeof(SectorContract[]));
        }
    }
}
