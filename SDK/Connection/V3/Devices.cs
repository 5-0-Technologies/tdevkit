using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDK
{
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
            return await GetRequest<DeviceContract>(subUrl);
        }

        public async Task<DeviceContract> GetDevice(string login, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.DevicesLogin, login, queryString);
            return await GetRequest<DeviceContract>(subUrl);
        }

        public async Task<DynamicDeviceContract[]> GetDynamicDevices(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.DevicesDynamicLocations, queryString);
            return await GetRequest<DynamicDeviceContract[]>(subUrl);
        }

        public async Task<DynamicDeviceShortContract[]> GetDynamicDevicesShort(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.DevicesDynamicLocationsShort, queryString);
            return await GetRequest<DynamicDeviceShortContract[]>(subUrl);
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
            return await PostRequest<ManDownResponseContract>(subUrl, manDownContract);
        }

        public async Task<ManDownResponseContract[]> ManDownBatch(ManDownContract[] manDownBatchContracts)
        {
            string subUrl = Address.UrlCombine(Address.Devices, "man-down/batch");
            return await PostRequest<ManDownResponseContract[]>(subUrl, manDownBatchContracts);
        }

        public async Task<ManDownResponseContract[]> ManDownBatch(ManDownBatchContract[] manDownBatchContracts)
        {
            string subUrl = Address.UrlCombine(Address.Devices, "man-down/batch");
            return await PostRequest<ManDownResponseContract[]>(subUrl, manDownBatchContracts);
        }

        public async Task RegisterDevice(DeviceRegistrationContract contract)
        {
            await PostRequest(Address.DevicesRegister, contract);
        }

        public async Task<SimpleLocationContract[]> GetDeviceLocations(int deviceId, long from, long to, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.DevicesLocations, $"?deviceId={deviceId}&from={from}&to={to}", queryString);
            return await GetRequest<SimpleLocationContract[]>(subUrl);
        }

        public async Task DeviceHeartbeat()
        {
            await PutRequest(Address.DevicesHeartbeat, new { });
        }

        public async Task UpdateDeviceStatus(DeviceStatusContract status)
        {
            await PutRequest(Address.DevicesDeviceStatus, status);
        }

        public async Task PostDeviceEvent(EventContract eventContract)
        {
            await PostRequest(Address.DevicesEvent, eventContract);
        }

        public async Task<HeatmapContract[]> GetDeviceHeatmap(long start, long stop, int[] deviceIds = null, string queryString = "")
        {
            string qs = $"?start={start}&stop={stop}";
            if (deviceIds != null)
            {
                foreach (var id in deviceIds)
                    qs += $"&deviceIds={id}";
            }
            string subUrl = Address.UrlCombine(Address.DevicesHeatmap) + qs + queryString;
            return await GetRequest<HeatmapContract[]>(subUrl);
        }

        public async Task<byte[]> GetDeviceApk(string code)
        {
            string subUrl = Address.UrlCombine(Address.DevicesApk, code);
            var response = await httpClient.GetAsync(subUrl);
            if (EnsureSuccessStatusCode && !response.IsSuccessStatusCode)
                await HandleError(response);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<string> GetDeviceVersion()
        {
            return await GetRequest<string>(Address.DevicesVersion);
        }

        public async Task PostDeviceVersion(object body)
        {
            await PostRequest(Address.DevicesVersion, body);
        }

        public async Task<string[]> GetTConnectVersions()
        {
            return await GetRequest<string[]>(Address.DevicesVersionsTConnect);
        }

        public async Task<string> GetDeviceVersion(string login)
        {
            return await GetRequest<string>(Address.UrlCombine(Address.Devices, login, "version"));
        }

        public async Task PostDeviceVersion(string login, object body)
        {
            await PostRequest(Address.UrlCombine(Address.Devices, login, "version"), body);
        }
    }
}
