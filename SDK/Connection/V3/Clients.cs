using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<ClientContract[]> GetClients(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Clients, queryString);
            return await GetRequest<ClientContract[]>(subUrl);
        }

        public async Task<ClientContract[]> GetAllClients(string queryString = "")
        {
            return await GetRequest<ClientContract[]>(Address.UrlCombine(Address.ClientsAll, queryString));
        }

        public async Task<ClientContract> AddClient(RegisterClientContract contract)
        {
            return await PostRequest<ClientContract>(Address.Clients, contract);
        }

        public async Task DeleteClient()
        {
            await DeleteRequest(Address.Clients);
        }

        public async Task DeleteClient(string login)
        {
            await DeleteRequest(Address.UrlCombine(Address.ClientsLogin, login));
        }

        public async Task<ClientContract> GetClientByLogin(string login)
        {
            return await GetRequest<ClientContract>(Address.UrlCombine(Address.ClientsGetByLogin, login));
        }

        public async Task<bool> ClientExists(string login)
        {
            return await GetRequest<bool>(Address.UrlCombine(Address.ClientsExists, login));
        }

        public async Task EmailValidation(object body)
        {
            await PostRequest(Address.ClientsEmailValidation, body);
        }

        public async Task<bool> ValidateClientToken()
        {
            return await GetRequest<bool>(Address.ClientsValidateToken);
        }
    }
}
