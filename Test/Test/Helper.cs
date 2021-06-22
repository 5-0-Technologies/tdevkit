using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tDevkit;

namespace Test
{
    class Helper
    {
        public static DevkitConnectorV3 GetConnector()
        {
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url("http://twin.develop.rtls.solutions:8080/api/")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("X1fprPtlkvolW1Bl47UQV4SoW8siY3n8QDQkDsGJ")
                .Version(ConnectionOptions.VERSION_3)
                .Login("ondrejicka")
                .Password("zJz1sJRUMNr4b4M")
                .Build();

            return (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);
        }
    }
}
