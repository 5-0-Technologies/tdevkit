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

        public async Task<AreaContract> AddArea(AreaWriteContract area)
        {
            string subUrl = Address.UrlCombine(Address.Areas);
            return await PostRequest<AreaContract>(subUrl, area);
        }

        public async Task UpdateArea(int id, object changes)
        {
            string subUrl = Address.UrlCombine(Address.Areas, id.ToString());
            await PatchRequest(subUrl, changes);
        }

        public async Task DeleteArea(int id)
        {
            string subUrl = Address.UrlCombine(Address.Areas, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }
    }
}
