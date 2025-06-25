using SDK.Contracts.Data.Aos;
using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<OrderDataContract[]> GetOrders(long start, long stop)
        {
            string subUrl = $"{Address.AosDataOrders}?start={start}&stop={stop}";
            var response = await GetRequest<OrderDataContract[]>(subUrl);

            return response;
        }
    }
}
