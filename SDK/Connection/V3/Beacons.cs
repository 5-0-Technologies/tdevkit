using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(5/5)
    public partial class DevkitConnectorV3
    {
        public async Task<BeaconContract[]> GetBeacons(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Beacons, queryString);
            var response = await GetRequest<BeaconContract[]>(subUrl);

            return response;
        }
        public async Task<BeaconContract> GetBeacon(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Beacons, Convert.ToString(id), queryString);
            var response = await GetRequest<BeaconContract>(subUrl);

            return response;
        }
        public async Task<BeaconContract> AddBeacon(BeaconWriteContract beaconContract)
        {
            string subUrl = Address.UrlCombine(Address.Beacons);
            var response = await PostRequest<BeaconContract>(subUrl, beaconContract);

            return response;
        }

        public async Task UpdateBeacon(int id, object changes)
        {
            string subUrl = Address.UrlCombine(Address.Beacons, id.ToString());
            await PatchRequest(subUrl, changes);
        }

        public async Task DeleteBeacon(int id)
        {
            string subUrl = Address.UrlCombine(Address.Beacons, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }
    }
}
