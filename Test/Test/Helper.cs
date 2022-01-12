using SDK;

namespace Test
{
    class Helper
    {
        public static DevkitConnectorV3 GetConnector()
        {
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url("https://twin.rtls.solutions/api/")
                .Client("Infotech")
                .ClientGuid("a4b82880-9dca-41f1-971a-73690dd8b222")
                .BranchGuid("87bdd503-fd94-46b7-ad0a-9e33fdd0c598")
                .Timeout(1000)
                .ApiKey("vzauHrBvLUcyJK0cLcnTQwd0fX4Cpp1MQ9DInQqW")
                .Version(ConnectionOptions.VERSION_3)
                .Build();

            return (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);
        }
    }
}
