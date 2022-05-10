using SDK.Contracts.Data;
using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    //(1/1)
    public partial class DevkitConnectorV3
    {
        public async Task<UserContract> GetUserInfo()
        {
            string subUrl = Address.UrlCombine(Address.Users);
            var response = await GetRequest<UserContract>(subUrl);

            return response;
        }
    }
}
