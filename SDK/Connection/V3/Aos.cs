using Core.Contract.V3.Aos;
using SDK.Models;
using System.Threading.Tasks;

namespace tDevkit
{
    //(0/15)
    public partial class DevkitConnectorV3
    {
        public async Task<OrderInfoContract[]> GetOrders()
        {
            string subUrl = UrlCombine(Address.AosOrders);
            var response = await GetRequest<OrderInfoContract[]>(subUrl);

            return response;
        }
    }
}
