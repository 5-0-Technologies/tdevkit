using SDK.Contracts.Data.Aos;
using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV5
    {
        public override async Task<OrderDataContract[]> GetOrders(long start, long stop)
        {
            string subUrl = $"{Address.AnalyticsAosOrders}?start={start}&stop={stop}";
            return await GetRequest<OrderDataContract[]>(subUrl);
        }
    }
}
