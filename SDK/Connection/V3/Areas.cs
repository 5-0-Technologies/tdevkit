using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<AreaContract[]> GetAreas(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Areas, queryString);
            return await GetRequest<AreaContract[]>(subUrl);
        }
        public async Task<AreaContract> GetArea(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Areas, Convert.ToString(id), queryString);
            return await GetRequest<AreaContract>(subUrl);
        }

        public async Task<AreaContract> AddArea(AreaContract area)
        {
            string subUrl = Address.UrlCombine(Address.Areas);
            return await PostRequest<AreaContract>(subUrl, area);
        }

        public async Task UpdateArea(AreaContract area)
        {
            string subUrl = Address.UrlCombine(Address.Areas, Convert.ToString(area.Id));
            await PatchRequest<AreaContract>(subUrl, area);
        }

        public async Task DeleteArea(int id)
        {
            string subUrl = Address.UrlCombine(Address.Areas, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }
    }
}
