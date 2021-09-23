using SDK.Contracts.Data;
using SDK.Models;
using System.Threading.Tasks;

namespace tDevkit
{
    //(1/1)
    public partial class DevkitConnectorV3
    {
        public async Task<UserContract> GetUserInfo()
        {
            string subUrl = Address.Users;
            var response = await GetRequest<UserContract>(subUrl);

            return response;
        }
    }
}
