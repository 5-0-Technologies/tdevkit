using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<QuantityContract[]> GetQuantities(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Quantities, queryString);
            return await GetRequest<QuantityContract[]>(subUrl);
        }
        public async Task<QuantityContract> GetQuantity(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Quantities, Convert.ToString(id), queryString);
            return await GetRequest<QuantityContract>(subUrl);
        }

        public async Task<QuantityContract> AddQuantity(QuantityContract Quantity)
        {
            string subUrl = Address.UrlCombine(Address.Quantities);
            return await PostRequest<QuantityContract>(subUrl, Quantity);
        }

        public async Task UpdateQuantity(QuantityContract Quantity)
        {
            string subUrl = Address.UrlCombine(Address.Quantities, Convert.ToString(Quantity.Id));
            await PatchRequest<QuantityContract>(subUrl, Quantity);
        }

        public async Task DeleteQuantity(int id)
        {
            string subUrl = Address.UrlCombine(Address.Quantities, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }
    }
}
