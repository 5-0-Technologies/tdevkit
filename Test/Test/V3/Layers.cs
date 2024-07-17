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
                .RespondWith(Response.Create().WithStatusCode(200)
                .WithBodyAsJson(
                    new LayerContract[] {
                        new LayerContract(){
                            Id = 1,
                        }
                    }));

            var response = await devkitConnector.GetLocalizationLayers(bodyContent);
            Assert.IsInstanceOfType(response, typeof(LayerContract[]));
        }

        [TestCategory("Layer")]
        [TestMethod]
        public async Task GetNoGoLayers_ShouldReturnLayers()
        {
            server.Given(Request.Create().WithPath(PATH_BASE + LAYERS + "/device/login").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                .WithBodyAsJson(new LayerContract[]
                {
                    new LayerContract()
                    {
                        Id = 1,
                    }
                }));

            var response = await devkitConnector.GetNoGoLayers("login");
            Assert.IsInstanceOfType(response, typeof(LayerContract[]));
        }

        [TestCategory("Layer")]
        [TestMethod]
        public async Task GetLayers_ShouldReturnLayers()
        {
            server.Given(Request.Create().WithPath(PATH_BASE + LAYERS).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                .WithBodyAsJson(new LayerContract[]
                {
                    new LayerContract()
                    {
                        Id = 1,
                    }
                }));

            var response = await devkitConnector.GetLayers();
            Assert.IsInstanceOfType(response, typeof(LayerContract[]));
        }

        [TestCategory("Layer")]
        [TestMethod]
        public async Task GetLayer_ShouldReturnLayer()
        {
            server.Given(Request.Create().WithPath(PATH_BASE + LAYERS + "/1").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200)
                               .WithBodyAsJson(new LayerContract()
                               {
                    Id = 1,
                }));

            var response = await devkitConnector.GetLayer(1);
            Assert.IsInstanceOfType(response, typeof(LayerContract));
        }

        public async Task AddLayer_ShouldReturnLayer()
        {
            var layer = new LayerContract()
            {
                Id = 1,
            };

            server.Given(Request.Create().WithPath(PATH_BASE + LAYERS).UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200)
                               .WithBodyAsJson(layer));

            var response = await devkitConnector.AddLayer(layer);
            Assert.IsInstanceOfType(response, typeof(LayerContract));
        }

        [TestCategory("Layer")]
        [TestMethod]
        public async Task UpdateLayer_ShouldReturnOk()
        {
            var layer = new LayerContract()
            {
                Id = 1,
            };

            server.Given(Request.Create().WithPath(PATH_BASE + LAYERS + "/1").UsingPatch())
                .RespondWith(Response.Create().WithStatusCode(200)
                                              .WithBodyAsJson(layer));

            await devkitConnector.UpdateLayer(layer);
        }

        [TestCategory("Layer")]
        [TestMethod]
        public async Task DeleteLayer_ShouldReturnOk()
        {
            server.Given(Request.Create().WithPath(PATH_BASE + LAYERS + "/1").UsingDelete())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.DeleteLayer(1);
        }
    }
}
