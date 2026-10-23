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

        [TestCategory("Client")]
        [TestMethod]
        public async Task GetAllClients_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS + "/all").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Clients.GetClients()));

            var response = await devkitConnector.GetAllClients();
            Assert.IsInstanceOfType(response, typeof(ClientContract[]));
        }

        [TestCategory("Client")]
        [TestMethod]
        public async Task AddClient_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS + "/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Clients.GetClient()));

            var response = await devkitConnector.AddClient(new RegisterClientContract { ClientName = "c" });
            Assert.IsInstanceOfType(response, typeof(ClientContract));
        }

        [TestCategory("Client")]
        [TestMethod]
        public async Task DeleteClient_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS + "/").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteClient();
        }

        [TestCategory("Client")]
        [TestMethod]
        public async Task DeleteClient_ByLogin_ShouldReturn200()
        {
            const string Login = "client1";
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS + "/login/" + Login).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteClient(Login);
        }

        [TestCategory("Client")]
        [TestMethod]
        public async Task GetClientByLogin_ShouldReturn200()
        {
            const string Login = "client1";
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS + "/getByLogin/" + Login).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Clients.GetClient()));

            var response = await devkitConnector.GetClientByLogin(Login);
            Assert.IsInstanceOfType(response, typeof(ClientContract));
        }

        [TestCategory("Client")]
        [TestMethod]
        public async Task ClientExists_ShouldReturn200()
        {
            const string Login = "client1";
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS + "/exists/" + Login).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(true));

            var response = await devkitConnector.ClientExists(Login);
            Assert.IsTrue(response);
        }

        [TestCategory("Client")]
        [TestMethod]
        public async Task EmailValidation_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS + "/emailValidation/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.EmailValidation(new { email = "a@b.c" });
        }

        [TestCategory("Client")]
        [TestMethod]
        public async Task ValidateClientToken_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CLIENTS + "/validateToken/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(true));

            var response = await devkitConnector.ValidateClientToken();
            Assert.IsTrue(response);
        }
    }
}
 