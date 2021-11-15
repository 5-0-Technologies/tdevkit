using SDK;
using System.Net.Http;

namespace SDK
{
    public partial class DevkitConnectorV3 : DevkitConnector
    {
        private readonly ConnectionOptions connectionOptions;
        protected HttpClient httpClient;
        private readonly string baseAddress;

        public DevkitConnectorV3(ConnectionOptions connectionOptions) : this(connectionOptions, new HttpClient())
        {

        }

        public DevkitConnectorV3(ConnectionOptions connectionOptions, HttpClient httpClient)
        {
            this.connectionOptions = connectionOptions;
            this.httpClient = httpClient;
            baseAddress = connectionOptions.Url + "/" + connectionOptions.Version + "/";

            resetHttpClientHeaders();
        }
    }
}
