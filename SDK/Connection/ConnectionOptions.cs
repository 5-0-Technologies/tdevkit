using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{

    public class ConnectionOptions
    {
        public const string VERSION_2 = "v2";
        public const string VERSION_3 = "v3";

        private string url;
        private string token;
        private string client;
        private string clientGuid;
        private string branchGuid;
        private int timeout;
        private string apiKey;
        private string version;
        private string login;
        private string password;


        public string Url { get => url; set => url = value; }
        public string Token { get => token; set => token = value; }
        public string Client { get => client; set => client = value; }
        public string ClientGuid { get => clientGuid; set => clientGuid = value; }
        public string BranchGuid { get => branchGuid; set => branchGuid = value; }
        public int Timeout { get => timeout; set => timeout = value; }
        public string ApiKey { get => apiKey; set => apiKey = value; }
        public string Version { get => version; set => version = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
    }
}
