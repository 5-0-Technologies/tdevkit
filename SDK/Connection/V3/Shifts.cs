using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<ShiftContract[]> GetShifts(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Shifts, queryString);
            var response = await GetRequest<ShiftContract[]>(subUrl);

            return response;
        }
        public async Task<ShiftContract> GetShift(int id, string queryString = "")
        {
            string subUrl = UrlCombine(Address.Shifts, Convert.ToString(id), queryString);
            var response = await GetRequest<ShiftContract>(subUrl);

            return response;
        }
    }
}
