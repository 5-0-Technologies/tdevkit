using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Quantities : Requests
    {
        const string QUANTITIES = "quantities";

        [TestCategory("Quantities")]
        [TestMethod]
        public async Task GetQuantity_ShouldReturnQuantityContract()
        {
            const int Id = 1;
            var bodyContent = TestData.Quantities.GetQuantity();

            server.Given(Request.Create().WithPath(PATH_BASE + QUANTITIES + "/" + Id).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            QuantityContract response = await devkitConnector.GetQuantity(1);
            Assert.IsInstanceOfType(response, typeof(QuantityContract));
        }

        [TestCategory("Quantities")]
        [TestMethod]
        public async Task GetQuantities_ShouldReturnQuantityContracts()
        {
            var bodyContent = TestData.Quantities.GetQuantities();

            server.Given(Request.Create().WithPath(PATH_BASE + QUANTITIES).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            QuantityContract[] response = await devkitConnector.GetQuantities();

            Assert.IsInstanceOfType(response, typeof(QuantityContract[]));
        }

        [TestCategory("Quantities")]
        [TestMethod]
        public async Task AddQuantity_ShouldReturnQuantityContract()
        {
            var bodyContent = TestData.Quantities.GetQuantity();

            server.Given(Request.Create().WithPath(PATH_BASE + QUANTITIES).UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            QuantityContract response = await devkitConnector.AddQuantity((QuantityWriteContract)bodyContent);
            Assert.IsInstanceOfType(response, typeof(QuantityContract));
        }

        [TestCategory("Quantities")]
        [TestMethod]
        public async Task UpdateQuantity()
        {
            var bodyContent = TestData.Quantities.GetQuantity();

            server.Given(Request.Create().WithPath(PATH_BASE + QUANTITIES + "/" + bodyContent.Id).UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateQuantity(bodyContent);
            Assert.IsTrue(true);
        }

        [TestCategory("Quantities")]
        [TestMethod]
        public async Task DeleteQuantity()
        {
            const int Id = 1;
            server.Given(Request.Create().WithPath(PATH_BASE + QUANTITIES + "/" + Id).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteQuantity(Id);
            Assert.IsTrue(true);
        }
    }
}
