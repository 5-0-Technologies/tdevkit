using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Layers : Requests
    {
        const string LAYERS = "layers";

        [TestCategory("Layer")]
        [TestMethod]
        public async Task GetLocalizationLayers_ShouldReturnLayers()
        {
            var bodyContent = new LoginContract()
            {
                Login = "login"
            };

            server.Given(Request.Create().WithPath(PATH_BASE + LAYERS + "/localization").UsingPost())
                .RespondWith(
                    Response.Create()
                    .WithStatusCode(200)
                    .WithBodyAsJson(new LayerContract[] {
                        new LayerContract(){
                            Id = 1,
                        }
                    })
            );

            var response = await devkitConnector.GetLocalizationLayers(bodyContent);

            Assert.IsInstanceOfType(response, typeof(LayerContract[]));
        }
    }
}
