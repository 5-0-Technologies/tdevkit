using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    //(1/1)
    public partial class DevkitConnectorV3
    {
        public async Task<ClientContract[]> GetClients(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Clients, queryString);
            var response = await GetRequest<ClientContract[]>(subUrl);

            return response;
        }
    }
}
