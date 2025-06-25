using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using SDK.Exceptions;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Users : Requests
    {
        const string USERS = "users/detail";

        [TestCategory("User")]
        [TestMethod]
        public async Task GetUserInfo_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Users error",
                Detail = "Failed to retrieve user info."
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + USERS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetUserInfo());
        }

        [TestCategory("User")]
        [TestMethod]
        public async Task GetUserInfo_GetUserInfo_ShouldReturn200()
        {
            var bodyContent = TestData.Users.GetUser();

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + USERS).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            UserContract response = await devkitConnector.GetUserInfo();

            Assert.IsInstanceOfType(response, typeof(UserContract));
        }
    }
} 