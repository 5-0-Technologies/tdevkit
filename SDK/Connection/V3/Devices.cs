using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Net.Http;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SDK
{
    //(7/9)
    public partial class DevkitConnectorV3
    {
        public async Task<DeviceContract[]> GetDevices(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Devices, queryString);
            return await GetRequest<DeviceContract[]>(subUrl);
        }

        public async Task<DeviceContract> GetDevice(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Devices, Convert.ToString(id), queryString);
            var response = await GetRequest<DeviceContract>(subUrl);

            return response;
        }

        public async Task<DeviceContract> GetDevice(string login, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.DevicesLogin, login, queryString);
            var response = await GetRequest<DeviceContract>(subUrl);

            return response;
        }

        public async Task<DynamicDeviceContract[]> GetDynamicDevices(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.DevicesDynamicLocations, queryString);
            var response = await GetRequest<DynamicDeviceContract[]>(subUrl);

            return response;
        }

        public async Task<DynamicDeviceContract[]> GetDynamicDevicesShort(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.DevicesDynamicLocationsShort, queryString);
            var response = await GetRequest<DynamicDeviceContract[]>(subUrl);

            return response;
        }

        public async Task<DeviceContract> AddDevice(DeviceWriteContract deviceContract)
        {
            string subUrl = Address.UrlCombine(Address.Devices);
            return await PostRequest<DeviceContract>(subUrl, deviceContract);
        }

        public async Task UpdateDevice(int id, object changes)
        {
            string subUrl = Address.UrlCombine(Address.Devices, id.ToString());
            await PatchRequest(subUrl, changes);
        }

        public async Task DeleteDevice(int id)
        {
            string subUrl = Address.UrlCombine(Address.Devices, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }

        public async Task<ManDownResponseContract> ManDown(ManDownContract manDownContract)
        {
            string subUrl = Address.UrlCombine(Address.Devices, "man-down");
            var response = await PostRequest<ManDownResponseContract>(subUrl, manDownContract);

            return response;
        }

        public async Task<ManDownResponseContract[]> ManDownBatch(ManDownContract[] manDownBatchContracts)
        {
            string subUrl = Address.UrlCombine(Address.Devices, "man-down/batch");
            var response = await PostRequest<ManDownResponseContract[]>(subUrl, manDownBatchContracts);

            return response;
        }

        public async Task<HttpResponseMessage> RegisterDevice()
        {
            return await Task.FromResult(new HttpResponseMessage());
        }

        public async Task<LocationContract[]> GetDeviceLocations(int deviceId, long from, long to, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.DevicesLocations, $"?deviceId={deviceId}&from={from}&to={to}", queryString);
            return await GetRequest<LocationContract[]>(subUrl);
        }
    }
}
