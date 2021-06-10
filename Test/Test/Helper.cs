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
            Console.WriteLine("Hello World!");
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url("http://twin.develop.rtls.solutions:8080/api/")
                //.Token("K169z9mIQ2Ln3UG34jOobsytFGGqYRwzCundpeM67G4=")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("X1fprPtlkvolW1Bl47UQV4SoW8siY3n8QDQkDsGJ")
                .Version(ConnectionOptions.VERSION_3)
                .Login("ondrejicka")
                .Password("zJz1sJRUMNr4b4M")
                .Build();
            //FeF/lTE9ZBPYMvKkQZnRMRK7loOXdfeD1qOcVMr00uQ=
            //Console.WriteLine("Url: " + connectionOptions.Url);
            Console.WriteLine("Token: " + connectionOptions.Token);
            Console.WriteLine("Client: " + connectionOptions.Client);
            Console.WriteLine("ClientGuid: " + connectionOptions.ClientGuid);
            Console.WriteLine("BranchGuid: " + connectionOptions.BranchGuid);
            Console.WriteLine("Timeout: " + connectionOptions.Timeout);
            Console.WriteLine("ApiKey: " + connectionOptions.ApiKey);
            Console.WriteLine("Version: " + connectionOptions.Version);
            Console.WriteLine("Login: " + connectionOptions.Login);
            Console.WriteLine("Password: " + connectionOptions.Password);

            return (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);
        }
    }
}
