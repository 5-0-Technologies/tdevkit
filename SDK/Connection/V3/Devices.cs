using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace tDevkit
{
    //(7/9)
    public partial class DevkitConnectorV3
    {
        public async Task<DeviceContract[]> GetDevices(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Devices, queryString);
            var response = await GetRequest<DeviceContract[]>(subUrl);

            return response;
        }

        public async Task<DeviceContract> GetDevice(int id, string queryString = "")
        {
            string subUrl = UrlCombine(Address.Devices, Convert.ToString(id), queryString);
            var response = await GetRequest<DeviceContract>(subUrl);

            return response;
        }

        public async Task<DeviceContract> GetDevice(string login, string queryString = "")
        {
            string subUrl = UrlCombine(Address.DevicesLogin, login, queryString);
            var response = await GetRequest<DeviceContract>(subUrl);

            return response;
        }

        public async Task<DynamicDeviceContract[]> GetDynamicDevices(string queryString = "")
        {
            string subUrl = UrlCombine(Address.DevicesDynamicLocations, queryString);
            var response = await GetRequest<DynamicDeviceContract[]>(subUrl);

            return response;
        }

        public async Task<DynamicDeviceContract[]> GetDynamicDevicesShort(string queryString = "")
        {
            string subUrl = UrlCombine(Address.DevicesDynamicLocationsShort, queryString);
            var response = await GetRequest<DynamicDeviceContract[]>(subUrl);

            return response;
        }

        public async Task<DeviceContract> AddDevice(DeviceContract deviceContract)
        {
            string subUrl = Address.Devices;
            var response = await PostRequest<AddDeviceResponseContract>(subUrl, deviceContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return (DeviceContract)response;
        }

        public async Task<PatchResponseContract> UpdateDevice(DeviceContract deviceContract)
        {
            if (deviceContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Device object has no Id.");
            }
            string subUrl = Address.Devices + deviceContract.Id;
            var response = await PatchRequest(subUrl, deviceContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return response;
        }

        public async Task<HttpResponseMessage> DeleteDevice(int id)
        {
            string subUrl = Address.Devices + id;
            var response = await DeleteRequest(subUrl);

            return response;
        }

        public async Task<ManDownBatchContract[]> ManDownBatch(ManDownBatchContract[] manDownBatchContracts)
        {
            string subUrl = Address.Devices + "man-down/batch";
            var response = await PostRequest<ManDownBatchContract[]>(subUrl, manDownBatchContracts);

            return response;
        }

        public async Task<HttpResponseMessage> RegisterDevice()
        {
            return null;
        }
    }
}
