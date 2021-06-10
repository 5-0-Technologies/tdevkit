using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    //(1/1)
    public partial class DevkitConnectorV3
    {
        public async Task<ClientContract[]> GetClients()
        {
            string subUrl = Address.Clients;
            var response = await GetRequest<ClientContract[]>(subUrl);

            return response;
        }
    }
}
