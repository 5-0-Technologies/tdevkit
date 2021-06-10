using SDK.Contracts.Data;
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
        public async Task<UserContract> GetUserInfo()
        {
            string subUrl = Address.Users;
            var response = await GetRequest<UserContract>(subUrl);

            return response;
        }
    }
}
