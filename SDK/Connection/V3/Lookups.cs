using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<LookupContract[]> GetLookups(string queryString = "")
        {
            return await GetRequest<LookupContract[]>(Address.UrlCombine(Address.Lookups, queryString));
        }

        public async Task<LookupContract> GetLookup(int id, string queryString = "")
        {
            return await GetRequest<LookupContract>(Address.UrlCombine(Address.Lookups, Convert.ToString(id), queryString));
        }

        public async Task<LookupContract> AddLookup(LookupWriteContract contract)
        {
            return await PostRequest<LookupContract>(Address.Lookups, contract);
        }

        public async Task UpdateLookup(int id, object changes)
        {
            await PatchRequest(Address.UrlCombine(Address.Lookups, id.ToString()), changes);
        }

        public async Task DeleteLookup(int id)
        {
            await DeleteRequest(Address.UrlCombine(Address.Lookups, Convert.ToString(id)));
        }
    }
}
