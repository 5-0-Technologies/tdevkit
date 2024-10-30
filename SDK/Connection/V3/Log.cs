using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
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
    }
}
