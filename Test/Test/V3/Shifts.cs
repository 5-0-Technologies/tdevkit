using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Shifts : Requests
    {
        const string SHIFTS = "shifts";

        [TestCategory("Shifts")]
        [TestMethod]
        public async Task GetShift_ShouldReturnShiftContract()
        {
            const int Id = 1;
            var bodyContent = new ShiftContract()
            {
                Id = 1,
                BranchId = 1,
                StartTime = 1599644652178,
                StopTime = 1599644652178,
                Title = "shift1"
            };

            server.Given(Request.Create().WithPath(PATH_BASE + SHIFTS + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            ShiftContract response = await devkitConnector.GetShift(1);
            Assert.IsInstanceOfType(response, typeof(ShiftContract));
        }

        [TestCategory("Shifts")]
        [TestMethod]
        public async Task GetShifts_ShouldReturnShiftContracts()
        {
            var bodyContent = new ShiftContract[]
            {
                new ShiftContract
                {
                    Id = 1,
                    BranchId = 1,
                    StartTime = 1599644652178,
                    StopTime = 1599644652178,
                    Title = "shift1"
                },
                new ShiftContract
                {
                    Id = 2,
                    BranchId = 1,
                    StartTime = 1599644652178,
                    StopTime = 1599644652178,
                    Title = "shift2"
                }
            };

            server.Given(Request.Create().WithPath(PATH_BASE + SHIFTS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            ShiftContract[] response = await devkitConnector.GetShifts();

            Assert.IsInstanceOfType(response, typeof(ShiftContract[]));
        }

        [TestCategory("Shifts")]
        [TestMethod]
        public async Task AddShift_ShouldReturnShiftContract()
        {
            var bodyContent = new ShiftContract
            {
                Id = 1,
                BranchId = 1,
                StartTime = 1599644652178,
                StopTime = 1599644652178,
                Title = "shift1"
            };

            server.Given(Request.Create().WithPath(PATH_BASE + SHIFTS).UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            ShiftContract response = await devkitConnector.AddShift(bodyContent);
            Assert.IsInstanceOfType(response, typeof(ShiftContract));
        }

        [TestCategory("Shifts")]
        [TestMethod]
        public async Task UpdateShift()
        {
            var bodyContent = new ShiftContract
            {
                Id = 1,
                BranchId = 1,
                StartTime = 1599644652178,
                StopTime = 1599644652178,
                Title = "shift1"
            };

            server.Given(Request.Create().WithPath(PATH_BASE + SHIFTS + "/" + bodyContent.Id).UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateShift(bodyContent);
            Assert.IsTrue(true);
        }

        [TestCategory("Shifts")]
        [TestMethod]
        public async Task DeleteShift()
        {
            const int Id = 1;
            server.Given(Request.Create().WithPath(PATH_BASE + SHIFTS + "/" + Id).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteShift(Id);
            Assert.IsTrue(true);
        }
    }
}
