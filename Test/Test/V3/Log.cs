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

    }
}
