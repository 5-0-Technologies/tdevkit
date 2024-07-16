using Microsoft.VisualStudio.TestTools.UnitTesting;
using WireMock.RequestBuilders;
using System.Threading.Tasks;
using WireMock.ResponseBuilders;
using System.Text.Json;

namespace Test.V3
{
    [TestClass]
    public class Accounts : Requests
    {

        const string ACCOUNT = "account";
        const string CONFIGURATION = "configuration";

        [TestCategory("GetAccountConfiguration")]
        [TestMethod]
        public async Task GetAccountConfiguration_ShouldReturnDeviceConfiguration_WhenDeviceAndConfigurationExists()
        {
            const string deviceLogin = "deviceLogin";
            const string configKey = "configKey";

            server.Given(Request.Create().WithPath(PATH_BASE + CONFIGURATION + $"/{ACCOUNT}/{deviceLogin}/{configKey}").UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson("{\"test\": \"test\"}"));

            var response = await devkitConnector.GetAccountConfiguration(deviceLogin, configKey);

            Assert.IsInstanceOfType(response, typeof(JsonDocument));
        }
    }
}
