using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Net.Http;
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
        public async Task<BeaconContract> AddBeacon(BeaconContract beaconContract)
        {
            string subUrl = Address.UrlCombine(Address.Beacons);
            var response = await PostRequest<AddBeaconResponseContract>(subUrl, beaconContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return (BeaconContract)response;
        }

        public async Task UpdateBeacon(BeaconContract beaconContract)
        {
            if (beaconContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Beacon object has no Id.");
            }
            string subUrl = Address.UrlCombine(Address.Beacons, Convert.ToString(beaconContract.Id));
            await PatchRequest<string>(subUrl, beaconContract);
        }

        public async Task DeleteBeacon(int id)
        {
            string subUrl = Address.UrlCombine(Address.Beacons, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }
    }
}
