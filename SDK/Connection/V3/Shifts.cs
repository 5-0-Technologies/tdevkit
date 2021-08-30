using Flurl;
using SDK.Contracts.Data;
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
        public async Task<ShiftContract[]> GetShifts(string queryString = "")
        {
            string subUrl = Url.Combine(Address.Shifts, queryString);
            var response = await GetRequest<ShiftContract[]>(subUrl);

            return response;
        }
        public async Task<ShiftContract> GetShift(int id, string queryString = "")
        {
            string subUrl = Url.Combine(Address.Shifts, Convert.ToString(id), queryString);
            var response = await GetRequest<ShiftContract>(subUrl);

            return response;
        }
    }
}
