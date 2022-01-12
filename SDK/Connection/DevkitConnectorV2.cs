using System.Net.Http;
using SDK;

namespace SDK
{
    public class DevkitConnectorV2 : DevkitConnector
    {
        public DevkitConnectorV2(ConnectionOptions connectionOptions) : base(connectionOptions)
        {
        }

        public DevkitConnectorV2(ConnectionOptions connectionOptions, HttpClient httpClient) : base(connectionOptions, httpClient)
        {
        }
    }
}
