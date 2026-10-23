using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
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

        [TestCategory("User")]
        [TestMethod]
        public async Task AddUser_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "users/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Users.GetUser()));

            var response = await devkitConnector.AddUser(new UserWriteContract { Login = "u1" });
            Assert.IsInstanceOfType(response, typeof(UserContract));
        }

        [TestCategory("User")]
        [TestMethod]
        public async Task RegisterUsers_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "users/register/true").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.RegisterUsers(true, new UsersRegistrationContract { Emails = new[] { "a@b.c" } });
        }

        [TestCategory("User")]
        [TestMethod]
        public async Task DeleteUser_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "users/" + Id).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteUser(Id);
        }
    }
}
 