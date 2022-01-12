using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDK
{
    //(7/9)
    public partial class DevkitConnectorV3
    {
        public async Task<DeviceContract[]> GetDevices(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Devices, queryString);
            return await GetRequest<DeviceContract[]>(subUrl);
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
            string subUrl = UrlCombine(Address.Devices);
            return await PostRequest<DeviceContract>(subUrl, deviceContract);
        }

        public async Task UpdateDevice(DeviceContract deviceContract)
        {
            if (deviceContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Device object has no Id.");
            }
            string subUrl = Address.Devices + deviceContract.Id;
            await PatchRequest(subUrl, deviceContract);
        }

        public async Task DeleteDevice(int id)
        {
            string subUrl = UrlCombine(Address.Devices, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }

        public async Task<ManDownResponseContract> ManDown(ManDownContract manDownContract)
        {
            string subUrl = UrlCombine(Address.Devices, "man-down");
            var response = await PostRequest<ManDownResponseContract>(subUrl, manDownContract);

            return response;
        }

        public async Task<ManDownResponseContract[]> ManDownBatch(ManDownContract[] manDownBatchContracts)
        {
            string subUrl = UrlCombine(Address.Devices, "man-down/batch");
            var response = await PostRequest<ManDownResponseContract[]>(subUrl, manDownBatchContracts);

            return response;
        }

        public async Task<HttpResponseMessage> RegisterDevice()
        {
            return await Task.FromResult(new HttpResponseMessage());
        }
    }
}
