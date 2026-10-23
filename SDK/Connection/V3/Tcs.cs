using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<DriverContract> GetTcsDriverInfo()
        {
            return await GetRequest<DriverContract>(Address.TcsDriverInfo);
        }
    }
}
