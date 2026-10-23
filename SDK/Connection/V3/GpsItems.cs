using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<GpsItemContract[]> GetGpsItems(string queryString = "")
        {
            return await GetRequest<GpsItemContract[]>(Address.UrlCombine(Address.GpsItems, queryString));
        }

        public async Task<GpsItemContract> GetGpsItem(int id, string queryString = "")
        {
            return await GetRequest<GpsItemContract>(Address.UrlCombine(Address.GpsItems, Convert.ToString(id), queryString));
        }

        public async Task<GpsItemContract> AddGpsItem(GpsItemWriteContract contract)
        {
            return await PostRequest<GpsItemContract>(Address.GpsItems, contract);
        }

        public async Task UpdateGpsItem(int id, object changes)
        {
            await PatchRequest(Address.UrlCombine(Address.GpsItems, id.ToString()), changes);
        }

        public async Task DeleteGpsItem(int id)
        {
            await DeleteRequest(Address.UrlCombine(Address.GpsItems, Convert.ToString(id)));
        }
    }
}
