using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK;
using WireMock.Server;
using WireMock.Settings;

namespace Test.V3
{
    [TestClass]
    public class Requests
    {
        protected const string URL = "http://localhost:8000";
        protected const string PATH_BASE = "/api/v3/";


        protected static WireMockServer server;
        protected static DevkitConnectorV3 devkitConnector;

        protected static WireMockServer Server { get => server; set => server = value; }

        static Requests()
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

        [ClassCleanup]
        public static void Cleanup()
        {
            server.Stop();
            server.Dispose();
        }
    }
}
