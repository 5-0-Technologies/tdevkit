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
    public class Beacons : Requests
    {
        const string BEACONS = "beacons";

        [TestCategory("Beacon")]
        [TestMethod]
        public async Task GetBeacons_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Specify the Error from Type property more.",
                Detail = "How to solve error."
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + BEACONS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetBeacons());
        }

        [TestCategory("Beacon")]
        [TestMethod]
        public async Task GetBeacons_GetAllBeacons_ShouldReturn200()
        {
            var bodyContent = TestData.Beacons.GetBeacons();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + BEACONS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            BeaconContract[] response = await devkitConnector.GetBeacons();

            Assert.IsInstanceOfType(response, typeof(BeaconContract[]));
        }

        [TestCategory("Beacon")]
        [TestMethod]
        public async Task GetBeacon_GetBeaconById_ShouldReturn200()
        {
            const int Id = 3;
            var bodyContent = TestData.Beacons.GetBeacon();

            server.Given(Request.Create().WithPath(PATH_BASE + BEACONS + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            BeaconContract response = await devkitConnector.GetBeacon(Id);

            Assert.IsInstanceOfType(response, typeof(BeaconContract));
        }

        [TestCategory("Beacon")]
        [TestMethod]
        public async Task AddBeacon_AddBeacon_ShouldReturn200()
        {
            var bodyContent = TestData.Beacons.GetBeacon();
            var writeContract = new BeaconWriteContract
            {
                Title = "Test Beacon",
                Mac = "00:00:00:00:00:00",
                X = 10.0f,
                Y = 10.0f,
                Z = 0.0f,
                Active = true,
                Position = true,
                Geofence = true,
                GeofenceRange = 20.0f,
                Cluster = "c1",
                UseGps = false
            };

            server.Given(Request.Create().WithPath(PATH_BASE + BEACONS).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            BeaconContract response = await devkitConnector.AddBeacon(writeContract);

            Assert.IsInstanceOfType(response, typeof(BeaconContract));
        }

        [TestCategory("Beacon")]
        [TestMethod]
        public async Task UpdateBeacon_UpdateBeacon_ShouldReturn200()
        {
            const int Id = 1;
            var changes = new { Title = "Updated Beacon" };

            server.Given(Request.Create().WithPath(PATH_BASE + BEACONS + "/" + Id).UsingPatch())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateBeacon(Id, changes);
        }

        [TestCategory("Beacon")]
        [TestMethod]
        public async Task DeleteBeacon_DeleteBeacon_ShouldReturn200()
        {
            const int Id = 1;

            server.Given(Request.Create().WithPath(PATH_BASE + BEACONS + "/" + Id).UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteBeacon(Id);
        }
    }
} 