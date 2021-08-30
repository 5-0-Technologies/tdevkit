using Flurl;
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
    //(7/9)
    public partial class DevkitConnectorV3
    {
        public async Task<DeviceContract[]> GetDevices(string queryString = "")
        {
            string subUrl = Url.Combine(Address.Devices, queryString);
            var response = await GetRequest<DeviceContract[]>(subUrl);

            return response;
        }
        public async Task<DeviceContract> GetDevice(int id, string queryString = "")
        {
            string subUrl = Url.Combine(Address.Devices, Convert.ToString(id), queryString);
            var response = await GetRequest<DeviceContract>(subUrl);

            return response;
        }
        public async Task<DeviceContract> GetDevice(string login, string queryString = "")
        {
            string subUrl = Url.Combine(Address.DevicesLogin, login, queryString);
            var response = await GetRequest<DeviceContract>(subUrl);

            return response;
        }
        public async Task<DynamicDeviceContract[]> GetDynamicDevices(string queryString = "")
        {
            string subUrl = Url.Combine(Address.DevicesDynamicLocations, queryString);
            var response = await GetRequest<DynamicDeviceContract[]>(subUrl);

            return response;
        }
        public async Task<DynamicDeviceContract[]> GetDynamicDevicesShort(string queryString = "")
        {
            string subUrl = Url.Combine(Address.DevicesDynamicLocationsShort, queryString);
            var response = await GetRequest<DynamicDeviceContract[]>(subUrl);

            return response;
        }
        public async Task<DeviceContract> AddDevice(DeviceContract deviceContract)
        {
            string subUrl = Address.Devices;
            var response = await PostRequest<AddDeviceResponseContract>(subUrl, deviceContract);

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

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
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            return response;
        }
        public async Task<HttpResponseMessage> DeleteDevice(int id)
        {
            string subUrl = Address.Devices + id;
            var response = await DeleteRequest(subUrl);

            return response;
        }
        public async Task<HttpResponseMessage> RegisterDevice()
        {
            return null;
        }
    }
}
