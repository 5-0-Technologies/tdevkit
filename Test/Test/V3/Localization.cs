using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Exceptions;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Localization : Requests
    {
        const string LOCALIZATION = "localization";

        [TestCategory("Localization")]
        [TestMethod]
        public async Task AddLocalizationData_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails
            {
                Title = "Localization data error",
                Detail = "Invalid localization data."
            };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + LOCALIZATION).UsingPost())
                    .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(async () => await devkitConnector.AddLocalizationData(TestData.Devices.GetLocalizationData()));
        }
    }
} 