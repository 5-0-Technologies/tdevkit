using SDK;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using SDK.Communication;
using SDK.Exceptions;
using SDK.Contracts.Data;
using SDK.Contracts.Communication;
using System.IO;

namespace tDevkit
{
    public partial class DevkitConnectorV3 : DevkitConnector
    {
        private ConnectionOptions connectionOptions;
        protected HttpClient httpClient;
        private string baseAddress;

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

    #region AOS (0/13)
    public partial class Base
    {
    }
    #endregion
}
