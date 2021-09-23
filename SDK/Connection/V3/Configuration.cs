using SDK.Models;
using System;
using System.Threading.Tasks;

namespace tDevkit
{
    //(3/3)
    public partial class DevkitConnectorV3
    {
        public async Task<ConfigurationContract> GetBranchConfiguration(string key)
        {
            string subUrl = Address.ConfigurationBranch + key;

            var task = await SendGetRequest(subUrl);

            var responseString = await ProcessResponse(task);
            ConfigurationContract response = new ConfigurationContract
            {
                Value = responseString
            };

            return response;
        }
        public async Task<ConfigurationContract> GetAccountConfiguration(string key)
        {
            string subUrl = Address.ConfigurationAccount + key;

            var task = await SendGetRequest(subUrl);

            var responseString = await ProcessResponse(task);
            ConfigurationContract response = new ConfigurationContract
            {
                Value = responseString
            };

            return response;
        }
        public async Task<long> GetConfigurationLastChange(string key)
        {
            string subUrl = Address.Configuration + key + "/last-change/";

            var task = await SendGetRequest(subUrl);

            var responseString = await ProcessResponse(task);

            return Convert.ToInt64(responseString);
        }
    }
}
