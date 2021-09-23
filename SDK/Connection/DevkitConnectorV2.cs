using System.Net.Http;
using tDevkit;

namespace SDK
{
    public class DevkitConnectorV2
    {
        private readonly ConnectionOptions connectionOptions;
        protected HttpClient httpClient;

        public DevkitConnectorV2(ConnectionOptions connectionOptions) : this(connectionOptions, new HttpClient())
        {
        }

        public DevkitConnectorV2(ConnectionOptions connectionOptions, HttpClient httpClient)
        {
            this.connectionOptions = connectionOptions;
            this.httpClient = httpClient;
        }

        //public override Task SendRequest()
        //{
        //    throw new NotImplementedException();
        //}

        //public override Task GetDevices()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
