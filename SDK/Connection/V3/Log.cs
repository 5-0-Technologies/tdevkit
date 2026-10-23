using SDK.Contracts.Communication;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<LogContract> AddLog(LogWriteContract logContract)
        {
            string subUrl = Address.UrlCombine(Address.LogAdd);
            return await PostRequest<LogContract>(subUrl, logContract);
        }

        public async Task<LogContract[]> GetLogs(string queryString = "")
        {
            return await GetRequest<LogContract[]>(Address.UrlCombine(Address.Logs, queryString));
        }

        public async Task<LogContract> GetLog(int id, string queryString = "")
        {
            return await GetRequest<LogContract>(Address.UrlCombine(Address.Logs, Convert.ToString(id), queryString));
        }
    }
}
