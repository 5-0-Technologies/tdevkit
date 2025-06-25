using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using SDK.Contracts.Communication;
using SDK.Exceptions;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Authorization : Requests
    {
        const string AUTHORIZATION = "Authorization";

        [TestCategory("Authorization")]
        [TestMethod]
        public async Task GetToken_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Authentication failed",
                Detail = "Invalid credentials."
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + AUTHORIZATION + "/Token").UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(401).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetToken());
        }

        [TestCategory("Authorization")]
        [TestMethod]
        public async Task GetToken_GetToken_ShouldReturn200()
        {
            var bodyContent = TestData.Authorization.GetAuthenticationResponse();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + AUTHORIZATION + "/Token").UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.GetToken();

            Assert.IsInstanceOfType(response, typeof(AuthenticationResponseContract));
            Assert.IsNotNull(response.Token);
        }

        [TestCategory("Authorization")]
        [TestMethod]
        public async Task Authenticate_AuthenticateWithCredentials_ShouldReturn200()
        {
            const string Login = "testuser";
            const string Password = "testpass";
            const bool SuperUser = false;
            var bodyContent = TestData.Authorization.GetAuthenticationResponse();

            server.Given(Request.Create().WithPath(PATH_BASE + AUTHORIZATION + "/Authenticate").UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.Authenticate(Login, Password, SuperUser);

            Assert.IsInstanceOfType(response, typeof(AuthenticationResponseContract));
            Assert.IsNotNull(response.Token);
        }

        [TestCategory("Authorization")]
        [TestMethod]
        public async Task Authenticate_AuthenticateWithSuperUser_ShouldReturn200()
        {
            const bool SuperUser = true;
            var bodyContent = TestData.Authorization.GetAuthenticationResponse();

            server.Given(Request.Create().WithPath(PATH_BASE + AUTHORIZATION + "/Authenticate").UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            var response = await devkitConnector.Authenticate(SuperUser);

            Assert.IsInstanceOfType(response, typeof(AuthenticationResponseContract));
            Assert.IsNotNull(response.Token);
        }

        [TestCategory("Authorization")]
        [TestMethod]
        public async Task Authenticate_AuthenticationError_ShouldThrowsException()
        {
            const string Login = "invaliduser";
            const string Password = "invalidpass";
            const bool SuperUser = false;
            var bodyContent = new ProblemDetails
            {
                Title = "Authentication failed",
                Detail = "Invalid credentials."
            };

            server.Given(Request.Create().WithPath(PATH_BASE + AUTHORIZATION + "/Authenticate").UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(401).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.Authenticate(Login, Password, SuperUser));
        }

        [TestCategory("Authorization")]
        [TestMethod]
        public async Task DeleteCurrentToken_DeleteToken_ShouldReturn200()
        {
            server.Given(Request.Create().WithPath(PATH_BASE + AUTHORIZATION + "/Token").UsingDelete())
                    .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteCurrentToken();
        }
    }
} 