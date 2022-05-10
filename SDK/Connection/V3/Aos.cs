using Core.Contract.V3.Aos;
using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    //(0/15)
    public partial class DevkitConnectorV3
    {
        public async Task<OrderInfoContract[]> GetOrders()
        {
            string subUrl = Address.UrlCombine(Address.AosOrders);
            var response = await GetRequest<OrderInfoContract[]>(subUrl);

            return response;
        }
    }
}
