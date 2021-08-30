using Flurl;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<AreaContract[]> GetAreas(string queryString = "")
        {
            string subUrl = Url.Combine(Address.Areas, queryString);
            var response = await GetRequest<AreaContract[]>(subUrl);

            return response;
        }
        public async Task<AreaContract> GetArea(int id, string queryString = "")
        {
            string subUrl = Url.Combine(Address.Areas, Convert.ToString(id), queryString);
            var response = await GetRequest<AreaContract>(subUrl);

            return response;
        }
    }
}
