using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(3/3)
    public partial class DevkitConnectorV3
    {
        public async Task<ConfigurationContract> GetBranchConfiguration(string key)
        {
            string subUrl = Address.UrlCombine(Address.ConfigurationBranch, key);

            var task = await httpClient.GetAsync(subUrl);

            var responseString = await JsonResponse<dynamic>(task);
            return new ConfigurationContract
            {
                Value = responseString
            };
        }

        public async Task<ConfigurationContract> GetAccountConfiguration(string key)
        {
            string subUrl = Address.UrlCombine(Address.ConfigurationAccount, key);

            var response = await httpClient.GetAsync(subUrl);

            var responseString = await JsonResponse<dynamic>(response);

            return new ConfigurationContract
            {
                Value = responseString
            };
        }

        public async Task<long> GetConfigurationLastChange(string key)
        {
            string subUrl = Address.UrlCombine(Address.Configuration, key, "/last-change");

            var response = await httpClient.GetAsync(subUrl);

            var responseString = response.Content.ReadAsStringAsync();

            return Convert.ToInt64(responseString);
        }
    }
}
