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
        public async Task<AreaContract[]> GetAreas()
        {
            string subUrl = Address.Areas;
            var response = await GetRequest<AreaContract[]>(subUrl);

            return response;
        }
        public async Task<AreaContract> GetArea(int id)
        {
            string subUrl = Address.Areas + id;
            var response = await GetRequest<AreaContract>(subUrl);

            return response;
        }
    }
}
