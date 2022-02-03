using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK;
using SDK.Contracts.Data;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Test.V3
{
    [TestClass]
    public class Layer
    {
        const string URL = "http://localhost:8000";
        const string PATH_BASE = "/api/v3/layers";
        static WireMockServer server;
        static DevkitConnectorV3 devkitConnector;

        protected static WireMockServer Server { get => server; set => server = value; }

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url(URL + "/api")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("X1fprPtlkvolW1Bl47UQV4SoW8siY3n8QDQkDsGJ")
                .Version(ConnectionOptions.VERSION_3)
                .Build();
            devkitConnector = (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);

            server = WireMockServer.Start(new WireMockServerSettings()
            {
                Urls = new[] { URL }
            });
        }

        [TestMethod]
        public async Task GetLocalizationLayers_ShouldReturnLayers()
        {
            var bodyContent = new LoginContract()
            {
                Login = "login"
            };

            server.Given(Request.Create().WithPath(PATH_BASE + "/localization").UsingPost())
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
