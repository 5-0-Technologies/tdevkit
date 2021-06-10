using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<BranchContract[]> GetBranches(string queryString = "")
        {
            string subUrl = Address.Branches + queryString;
            var response = await GetRequest<BranchContract[]>(subUrl);

            return response;
        }
        public async Task<BranchContract> GetBranch(int id)
        {
            string subUrl = Address.Branches + id;
            var response = await GetRequest<BranchContract>(subUrl);

            return response;
        }
    }
}
