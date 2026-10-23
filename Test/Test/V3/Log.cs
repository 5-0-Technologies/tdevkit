using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Communication;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Log : Requests
    {
        const string LOG = "logs";

        [TestCategory("Log")]
        [TestMethod]
        public async Task PostLog_ShouldReturnLogContract()
        {
            var bodyContent = new LogWriteContract()
            {
                Login = "login",
                AccountId = 1,
                Level = "Info",
                Message = "message"
            };

            server.Given(Request.Create().WithPath(PATH_BASE + LOG).UsingPost())
                .RespondWith(
                    Response.Create()
                    .WithStatusCode(200)
                    .WithBodyAsJson(bodyContent)
            );

            var response = await devkitConnector.AddLog(bodyContent);

            Assert.IsInstanceOfType(response, typeof(LogContract));
        }

        [TestCategory("Log")]
        [TestMethod]
        public async Task GetLogs_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOG).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new LogContract[0]));

            var response = await devkitConnector.GetLogs();
            Assert.IsInstanceOfType(response, typeof(LogContract[]));
        }

        [TestCategory("Log")]
        [TestMethod]
        public async Task GetLog_ShouldReturn200()
        {
            const int Id = 1;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOG + "/" + Id).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new LogContract { Id = Id }));

            var response = await devkitConnector.GetLog(Id);
            Assert.IsInstanceOfType(response, typeof(LogContract));
        }
    }
}

