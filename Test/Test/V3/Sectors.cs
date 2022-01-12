using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Test
{
    public class SectorTest
    {
        protected const string URL = "http://localhost:8000";
        private const string PATH_BASE = "/api/v3/sectors";
        protected static WireMockServer server;
        protected static DevkitConnectorV3 devkitConnector;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url(URL + "/api")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("X1fprPtlkvolW1Bl47UQV4SoW8siY3n8QDQkDsGJ")
                .Version(ConnectionOptions.VERSION_3)
                .Build();
            devkitConnector = (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);

            server = WireMockServer.Start(new WireMockServerSettings()
            {
                Urls = new[] { URL }
            });
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            server.Stop();
        }

        [TestMethod]
        public async Task GetSector_GetDeviceByLogin_ShouldReturn200()
        {
            var bodyContent = new SectorContract()
            {
                Id =  1,
                Guid = Guid.NewGuid(),
            };

            server.Given(Request.Create().WithPath(PATH_BASE).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SectorContract[] { bodyContent }));

            SectorContract[] response = await devkitConnector.GetSectors();

            Assert.IsInstanceOfType(response, typeof(SectorContract[]));
        }

        //[TestMethod]
        //public async Task Sectors3()
        //{
        //    SectorContract sector = await devkitConnector.AddSector(TestData.GetSector());
        //    Assert.IsNotNull(sector);
        //    await devkitConnector.DeleteSector(sector.Id);

        //    SectorContract sector2 = null;
        //    try
        //    {
        //        sector2 = await devkitConnector.GetSector(sector.Id);
        //    }
        //    catch (NotFoundException) { }
        //    Assert.IsNull(sector2);
        //}

        //[TestMethod]
        //public async Task Sectors4()
        //{
        //    //SectorContract sectorData = TestData.GetSector();
        //    //SectorContract sector = await devkitConnector.AddSector(sectorData);
        //    //sector.BarrierWidth = 20;
        //    //try
        //    //{
        //    //    var message = await devkitConnector.UpdateSector(sector);
        //    //    var temp = 0;
        //    //}
        //    //catch (BadRequestException exception)
        //    //{
        //    //    Assert.IsNotNull(null);
        //    //}
        //    //Assert.IsNotNull(sector);
        //    //await devkitConnector.DeleteSector(sector.Id);
        //    await Task.CompletedTask;
        //}


        //[TestMethod]
        //public async Task Sectors5()
        //{
        //    //Delete je otestovany v add a update
        //    await Task.CompletedTask;
        //}
    }
}
