using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Tcs : Requests
    {
        const string DRIVER_INFO = "tcs/driver-info";

        [TestCategory("Tcs")]
        [TestMethod]
        public async Task GetTcsDriverInfo_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails { Title = "Tcs error", Detail = "Failed." };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DRIVER_INFO + "/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.GetTcsDriverInfo());
        }

        [TestCategory("Tcs")]
        [TestMethod]
        public async Task GetTcsDriverInfo_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + DRIVER_INFO + "/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new DriverContract { DriverName = "d" }));

            var response = await devkitConnector.GetTcsDriverInfo();
            Assert.IsInstanceOfType(response, typeof(DriverContract));
        }
    }
}
