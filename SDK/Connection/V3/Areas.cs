using SDK.Models;
using System;
using System.Threading.Tasks;

namespace tDevkit
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<AreaContract[]> GetAreas(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Areas, queryString);
            var response = await GetRequest<AreaContract[]>(subUrl);

            return response;
        }
        public async Task<AreaContract> GetArea(int id, string queryString = "")
        {
            string subUrl = UrlCombine(Address.Areas, Convert.ToString(id), queryString);
            var response = await GetRequest<AreaContract>(subUrl);

            return response;
        }
    }
}
