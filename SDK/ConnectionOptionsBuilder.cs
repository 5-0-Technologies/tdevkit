using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    public interface IOptionsBuilder
    {
        ConnectionOptions Build();
    }

    public class ConnectionOptionsBuilder : IOptionsBuilder
    {
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


        public ConnectionOptionsBuilder Url(string url)
        {
            this.url = url;
            return this;
        }

        public ConnectionOptionsBuilder Token(string token)
        {
            this.token = token;
            return this;
        }

        public ConnectionOptionsBuilder Client(string client)
        {
            this.client = client;
            return this;
        }

        public ConnectionOptionsBuilder ClientGuid(string clientGuid)
        {
            this.clientGuid = clientGuid;
            return this;
        }

        public ConnectionOptionsBuilder BranchGuid(string branchGuid)
        {
            this.branchGuid = branchGuid;
            return this;
        }

        public ConnectionOptionsBuilder Timeout(int timeout)
        {
            this.timeout = timeout;
            return this;
        }

        public ConnectionOptionsBuilder ApiKey(string apiKey)
        {
            this.apiKey = apiKey;
            return this;
        }

        public ConnectionOptionsBuilder Version(string version)
        {
            this.version = version;
            return this;
        }

        public ConnectionOptionsBuilder Login(string login)
        {
            this.login = login;
            return this;
        }

        public ConnectionOptionsBuilder Password(string password)
        {
            this.password = password;
            return this;
        }

        public ConnectionOptions Build()
        {
            return new ConnectionOptions
            {
                Url = this.url,
                Token = this.token,
                ClientGuid = this.clientGuid,
                Client = this.client,
                BranchGuid = this.branchGuid,
                Timeout = this.timeout,
                ApiKey = this.apiKey,
                Version = this.version,
                Login = this.login,
                Password = this.password
            };
        }
    }
}
