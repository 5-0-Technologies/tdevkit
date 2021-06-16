using Core.Contract.V3.Aos;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    //(0/15)
    public partial class DevkitConnectorV3
    {
        public async Task<OrderInfoContract[]> GetOrders()
        {
            string subUrl = Address.AosOrders;
            var response = await GetRequest<OrderInfoContract[]>(subUrl);

            return response;
        }
    }
}
