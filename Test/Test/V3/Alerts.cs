using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data.Alerts;
using SDK.Exceptions;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Alerts : Requests
    {
        const string CHECKS = "alerts/checks";
        const string NOTIFICATIONS = "alerts/notifications";

        [TestCategory("Alert")]
        [TestMethod]
        public async Task GetAlertChecks_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails { Title = "Alerts error", Detail = "Failed." };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CHECKS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetAlertChecks());
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task GetAlertChecks_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CHECKS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { new CheckContract { Id = 1 } }));

            var response = await devkitConnector.GetAlertChecks();
            Assert.IsInstanceOfType(response, typeof(CheckContract[]));
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task GetAlertCheck_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CHECKS + "/" + Id).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new CheckContract { Id = Id }));

            var response = await devkitConnector.GetAlertCheck(Id);
            Assert.IsInstanceOfType(response, typeof(CheckContract));
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task AddAlertCheck_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CHECKS + "/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new CheckContract { Id = 1 }));

            var response = await devkitConnector.AddAlertCheck(new CheckWriteContract { Title = "t" });
            Assert.IsInstanceOfType(response, typeof(CheckContract));
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task UpdateAlertCheck_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CHECKS + "/" + Id).UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateAlertCheck(Id, new { Title = "u" });
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task DeleteAlertCheck_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + CHECKS + "/" + Id).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteAlertCheck(Id);
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task GetAlertNotifications_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + NOTIFICATIONS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { new NotificationContract { Id = 1 } }));

            var response = await devkitConnector.GetAlertNotifications();
            Assert.IsInstanceOfType(response, typeof(NotificationContract[]));
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task GetAlertNotification_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + NOTIFICATIONS + "/" + Id).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new NotificationContract { Id = Id }));

            var response = await devkitConnector.GetAlertNotification(Id);
            Assert.IsInstanceOfType(response, typeof(NotificationContract));
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task AddAlertNotification_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + NOTIFICATIONS + "/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new NotificationContract { Id = 1 }));

            var response = await devkitConnector.AddAlertNotification(new NotificationWriteContract { Title = "t" });
            Assert.IsInstanceOfType(response, typeof(NotificationContract));
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task UpdateAlertNotification_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + NOTIFICATIONS + "/" + Id).UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.UpdateAlertNotification(Id, new { Title = "u" });
        }

        [TestCategory("Alert")]
        [TestMethod]
        public async Task DeleteAlertNotification_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + NOTIFICATIONS + "/" + Id).UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteAlertNotification(Id);
        }
    }
}
