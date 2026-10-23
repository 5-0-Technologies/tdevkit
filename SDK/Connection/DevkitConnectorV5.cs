using System.Net.Http;

namespace SDK
{
    public partial class DevkitConnectorV5 : DevkitConnectorV3
    {
        public DevkitConnectorV5(ConnectionOptions connectionOptions) : base(connectionOptions)
        {
        }

        public DevkitConnectorV5(ConnectionOptions connectionOptions, HttpClient httpClient) : base(connectionOptions, httpClient)
        {
        }
    }
}
