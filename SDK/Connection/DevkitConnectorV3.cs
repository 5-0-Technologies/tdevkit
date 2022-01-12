using SDK;
using System.Net.Http;

namespace SDK
{
    public partial class DevkitConnectorV3 : DevkitConnector
    {

        public DevkitConnectorV3(ConnectionOptions connectionOptions) : base(connectionOptions)
        {
        }

        public DevkitConnectorV3(ConnectionOptions connectionOptions, HttpClient httpClient) : base(connectionOptions, httpClient)
        {
        }
    }
}
