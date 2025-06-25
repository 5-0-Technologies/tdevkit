using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using SDK.Exceptions;
using System.Text.Json;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Configuration : Requests
    {
        const string CONFIGURATION = "configuration";

        [TestCategory("Configuration")]
        [TestMethod]
        public async Task GetAccountConfiguration_GetConfigurationByLogin_ShouldReturn200()
        {
            const string Login = "testuser";
            const string Key = "test-key";
            var bodyContent = new { value = "test-value" };

            server.Given(Request.Create().WithPath(PATH_BASE + CONFIGURATION + "/account/" + Login + "/" + Key).UsingGet())
                    .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(bodyContent));

            JsonDocument response = await devkitConnector.GetAccountConfiguration(Login, Key);

            Assert.IsInstanceOfType(response, typeof(JsonDocument));
        }
    }
} 