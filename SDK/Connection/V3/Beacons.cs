using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    //(5/5)
    public partial class DevkitConnectorV3
    {
        public async Task<BeaconContract[]> GetBeacons()
        {
            string subUrl = Address.Beacons;
            var response = await GetRequest<BeaconContract[]>(subUrl);

            return response;
        }
        public async Task<BeaconContract> AddBeacon(BeaconContract beaconContract)
        {
            string subUrl = Address.Beacons;
            var response = await PostRequest<AddBeaconResponseContract>(subUrl, beaconContract);

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            return (BeaconContract)response;
        }
        public async Task<HttpResponseMessage> DeleteBeacon(int id)
        {
            string subUrl = Address.Beacons + id;
            var response = await DeleteRequest(subUrl);

            return response;
        }
        public async Task<BeaconContract> GetBeacon(int id)
        {
            string subUrl = Address.Beacons + id;
            var response = await GetRequest<BeaconContract>(subUrl);

            return response;
        }
        public async Task<PatchResponseContract> UpdateBeacon(BeaconContract beaconContract)
        {
            if (beaconContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Beacon object has no Id.");
            }
            string subUrl = Address.Beacons + beaconContract.Id;
            var response = await PatchRequest(subUrl, beaconContract);

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            return response;
        }
    }
}
