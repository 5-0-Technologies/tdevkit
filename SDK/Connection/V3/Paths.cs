using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<PathContract[]> GetPaths(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Paths, queryString);
            return await GetRequest<PathContract[]>(subUrl);
        }

        public async Task<PathContract> GetPath(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Paths, Convert.ToString(id), queryString);
            return await GetRequest<PathContract>(subUrl);
        }
    }
}