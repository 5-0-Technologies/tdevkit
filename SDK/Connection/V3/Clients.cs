using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    //(1/1)
    public partial class DevkitConnectorV3
    {
        public async Task<ClientContract[]> GetClients(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Clients, queryString);
            var response = await GetRequest<ClientContract[]>(subUrl);

            return response;
        }
    }
}
