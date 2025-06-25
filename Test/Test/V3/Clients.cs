using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using SDK.Communication;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Clients : Requests
    {
        const string CLIENTS = "clients";

        [TestCategory("Client")]
        [TestMethod]
        public async Task GetClients_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Clients error",
                Detail = "Failed to retrieve clients."
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetClients());
        }

        [TestCategory("Client")]
        [TestMethod]
        public async Task GetClients_GetAllClients_ShouldReturn200()
        {
            var bodyContent = TestData.Clients.GetClients();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            ClientContract[] response = await devkitConnector.GetClients();

            Assert.IsInstanceOfType(response, typeof(ClientContract[]));
        }
    }
} 