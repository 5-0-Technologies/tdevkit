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

        public async Task<PostResponseContract> AddSensorData(SensorDataContract shiftContract)
        {
            string subUrl = Address.UrlCombine(Address.SensorDatas);
            var response = await PostRequest<AddSensorDataResponseContract>(subUrl, shiftContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return response;
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
