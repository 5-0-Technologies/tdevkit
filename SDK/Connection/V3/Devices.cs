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
    //(7/8)
    public partial class DevkitConnectorV3
    {
        public async Task<DeviceContract[]> GetDevices()
        {
            string subUrl = Address.Devices;
            var response = await GetRequest<DeviceContract[]>(subUrl);

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
        public async Task<DeviceContract> GetDevice(int id)
        {
            string subUrl = Address.Devices + id;
            var response = await GetRequest<DeviceContract>(subUrl);

            return response;
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
        public async Task<DeviceContract> GetDevice(string login)
        {
            string subUrl = Address.DevicesLogin + login;
            var response = await GetRequest<DeviceContract>(subUrl);

            return response;
        }
        public async Task<DynamicDeviceContract[]> GetDynamicDevices()
        {
            string subUrl = Address.DevicesDynamicLocations;
            var response = await GetRequest<DynamicDeviceContract[]>(subUrl);

            return response;
        }
        public async Task<DynamicDeviceContract[]> GetDynamicDevicesShort()
        {
            string subUrl = Address.DevicesDynamicLocationsShort;
            var response = await GetRequest<DynamicDeviceContract[]>(subUrl);

            return response;
        }
        public async Task<HttpResponseMessage> RegisterDevice()
        {
            return null;
        }
    }
}
