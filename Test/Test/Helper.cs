using SDK;

namespace Test
{
    class Helper
    {
        public static DevkitConnectorV3 GetConnector()
        {
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url("http://192.168.30.95/twin.develop.rtls.solutions/api/")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("X1fprPtlkvolW1Bl47UQV4SoW8siY3n8QDQkDsGJ")
                .Version(ConnectionOptions.VERSION_3)
                .Build();

            return (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);
        }
    }
}
