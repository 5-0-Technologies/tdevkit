using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<UserContract> GetUserInfo()
        {
            return await GetRequest<UserContract>(Address.UsersDetail);
        }

        public async Task<UserContract> AddUser(UserWriteContract user)
        {
            return await PostRequest<UserContract>(Address.Users, user);
        }

        public async Task RegisterUsers(bool sendEmail, UsersRegistrationContract contract)
        {
            await PostRequest(Address.UrlCombine(Address.UsersRegister, sendEmail.ToString().ToLowerInvariant()), contract);
        }

        public async Task DeleteUser(int id)
        {
            await DeleteRequest(Address.UrlCombine(Address.Users, Convert.ToString(id)));
        }
    }
}
