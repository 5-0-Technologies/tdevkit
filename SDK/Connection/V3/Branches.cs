using SDK.Models;
using System;
using System.Threading.Tasks;

namespace tDevkit
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<BranchContract[]> GetBranches(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Branches, queryString);
            var response = await GetRequest<BranchContract[]>(subUrl);

            return response;
        }
        public async Task<BranchContract> GetBranch(int id, string queryString = "")
        {
            string subUrl = UrlCombine(Address.Branches, Convert.ToString(id), queryString);
            var response = await GetRequest<BranchContract>(subUrl);

            return response;
        }
    }
}
