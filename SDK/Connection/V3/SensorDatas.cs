using SDK.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<SensorDataContract[]> GetSensorDatas(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.SensorDatas, queryString);
            var response = await GetRequest<SensorDataContract[]>(subUrl);

            return response;
        }

        public async Task<SensorDataContract> GetSensorData(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.SensorDatas, Convert.ToString(id), queryString);
            var response = await GetRequest<SensorDataContract>(subUrl);

            return response;
        }

        public async Task<SensorDataContract> AddSensorData(SensorDataWriteContract shiftContract)
        {
            string subUrl = Address.UrlCombine(Address.SensorDatas);
            return await PostRequest<SensorDataContract>(subUrl, shiftContract);
        }

        public async Task UpdateSensorData(int id, object changes)
        {
            string subUrl = Address.UrlCombine(Address.SensorDatas, id.ToString());
            await PatchRequest(subUrl, changes);
        }

        public async Task DeleteSensorData(int id)
        {
            string subUrl = Address.UrlCombine(Address.SensorDatas, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }
    }
}
