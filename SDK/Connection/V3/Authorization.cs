using SDK;
using SDK.Communication;
using SDK.Exceptions;
using SDK.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDK
{
    //(3/3)
    public partial class DevkitConnectorV3
    {
        public async Task DeleteCurrentToken()
        {
            string subUrl = UrlCombine(Address.AuthorizationToken);

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Token", connectionOptions.Token);

            await DeleteRequest(subUrl);

            connectionOptions.Token = null;

            ResetHttpClientHeaders();
        }

        public async Task<AuthenticationResponseContract> GetToken()
        {
            string subUrl = UrlCombine(Address.AuthorizationToken);

            var response = await GetRequest<AuthenticationResponseContract>(subUrl);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            connectionOptions.Token = response.Token;
            if (response.Client != null)
            {
                connectionOptions.ClientGuid = response.Client;
            }

            if (response.Branch != null)
            {
                connectionOptions.BranchGuid = response.Branch;
            }

            ResetHttpClientHeaders();

            return response;
        }
        public async Task<AuthenticationResponseContract> Authenticate(bool superUser)
        {
            return await Authenticate(connectionOptions.Login, connectionOptions.Password, superUser);
        }
        public async Task<AuthenticationResponseContract> Authenticate(string login, string password, bool superUser)
        {
            string subUrl = UrlCombine(Address.AuthorizationAuthenticate);

            CredentialContract credentialContract = new CredentialContract
            {
                Login = login,
                Password = password
            };


            if (!superUser)
            {
                credentialContract.Client = connectionOptions.Client;
            }

            var response = await PostRequest<AuthenticationResponseContract>(subUrl, credentialContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            connectionOptions.Token = response.Token;
            if (response.Client != null)
            {
                connectionOptions.ClientGuid = response.Client;
            }

            if (response.Branch != null)
            {
                connectionOptions.BranchGuid = response.Branch;
            }

            ResetHttpClientHeaders();

            return response;
        }
    }
}
