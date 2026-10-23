using SDK.Communication;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<SensorContract[]> GetSensors(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Sensors, queryString);
            return await GetRequest<SensorContract[]>(subUrl);
        }

        public async Task<SensorContract> GetSensor(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Sensors, Convert.ToString(id), queryString);
            return await GetRequest<SensorContract>(subUrl);
        }

        public async Task<SensorContract> GetSensor(string login, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.SensorsLogin, login, queryString);
            return await GetRequest<SensorContract>(subUrl);
        }

        public async Task<SensorResponseContract[]> AddSensor(SensorWriteContract sensorContract)
        {
            string subUrl = Address.UrlCombine(Address.Sensors);
            return await PostRequest<SensorResponseContract[]>(subUrl, sensorContract);
        }

        public async Task UpdateSensor(int id, object changes)
        {
            string subUrl = Address.UrlCombine(Address.Sensors, id.ToString());
            await PatchRequest(subUrl, changes);
        }

        public async Task DeleteSensor(int id)
        {
            string subUrl = Address.UrlCombine(Address.Sensors, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }

        public async Task<SensorResponseContract[]> AddSensorData(SensorBatchContract[] sensors)
        {
            string subUrl = Address.UrlCombine(Address.SensorsAddDataBatch);
            return await PostRequest<SensorResponseContract[]>(subUrl, sensors);
        }

        public async Task<SensorDataResponseContract[]> AddSensorData(SensorDataBatchContract[] sensorData)
        {
            string subUrl = Address.UrlCombine(Address.SensorsAddData);
            return await PostRequest<SensorDataResponseContract[]>(subUrl, sensorData);
        }

        public async Task<SensorQuantityContract[]> GetSensorQuantities(int sensorId, long start, long stop, string[] quantities = null, string aggregation = "mean")
        {
            string qs = $"?sensorId={sensorId}&start={start}&stop={stop}&aggregation={aggregation}";
            if (quantities != null)
            {
                foreach (var q in quantities)
                    qs += $"&quantities={Uri.EscapeDataString(q)}";
            }
            string subUrl = Address.UrlCombine(Address.SensorsAddData) + qs;
            return await GetRequest<SensorQuantityContract[]>(subUrl);
        }

        public async Task<SensorAppInfoContract> GetSensorAppInfo()
        {
            string subUrl = Address.UrlCombine(Address.SensorsAppInfo);
            return await GetRequest<SensorAppInfoContract>(subUrl);
        }

        public async Task<byte[]> GetSensorAppFile()
        {
            string subUrl = Address.UrlCombine(Address.SensorsAppFile);
            var response = await httpClient.GetAsync(subUrl);
            if (EnsureSuccessStatusCode && !response.IsSuccessStatusCode)
                await HandleError(response);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
