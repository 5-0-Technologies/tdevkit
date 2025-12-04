using SDK.Communication;
using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SDK
{
    //(9/10)
    public partial class DevkitConnectorV3
    {
        public async Task<SensorContract[]> GetSensors(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Sensors, queryString);
            var response = await GetRequest<SensorContract[]>(subUrl);

            return response;
        }
        public async Task<SensorContract> GetSensor(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Sensors, Convert.ToString(id), queryString);
            var response = await GetRequest<SensorContract>(subUrl);

            return response;
        }
        public async Task<SensorContract> GetSensor(string login, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.SensorsLogin, login, queryString);
            var response = await GetRequest<SensorContract>(subUrl);

            return response;
        }
        public async Task<SensorContract[]> AddSensor(SensorWriteContract sensorContract)
        {
            string subUrl = Address.UrlCombine(Address.Sensors);
            var response = await PostRequest<AddSensorResponseContract[]>(subUrl, sensorContract);

            if (response != null)
            {
                for (int i = 0; i < response.Length; i++)
                {
                    if (response[i].ErrorMessage != null)
                    {
                        throw new ServerResponseException(ServerResponseException.message + " " + response[i].ErrorMessage);
                    }
                }
            }

            return response?.Select(r => (SensorContract)r).ToArray() ?? Array.Empty<SensorContract>();
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
        public async Task<PostResponseContract[]> AddSensorData(SensorWriteContract[] sensors)
        {
            string subUrl = Address.UrlCombine(Address.SensorsAddDataBatch);
            var response = await PostRequest<AddSensorDataResponseContract[]>(subUrl, sensors);


            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].SensorData != null)
                {
                    for (int j = 0; j < response[i].SensorData.Length; j++)
                    {
                        var sensorDataResult = response[i].SensorData[j];
                        if (sensorDataResult.ErrorMessage != null)
                        {
                            throw new ServerResponseException(ServerResponseException.message +
                                " Quantity: " + sensorDataResult.Quantity + " - " + sensorDataResult.ErrorMessage);
                        }
                    }
                }

                if (response[i].ErrorMessage != null)
                {
                    throw new ServerResponseException(ServerResponseException.message + " " + response[i].ErrorMessage);
                }
            }

            return response;
        }
        public async Task<PostResponseContract> AddSensorData(SensorDataWriteContract[] sensorData)
        {
            string subUrl = Address.UrlCombine(Address.SensorsAddData);
            var response = await PostRequest<SensorDataResponseContract[]>(subUrl, sensorData); //AddSensorDataResponseContract

            if (response != null)
            {
                for (int i = 0; i < response.Length; i++)
                {
                    var sensorDataResult = response[i];
                    if (sensorDataResult.ErrorMessage != null)
                    {
                        throw new ServerResponseException(ServerResponseException.message +
                            " Quantity: " + sensorDataResult.Quantity + " - " + sensorDataResult.ErrorMessage);
                    }
                }
            }

            return new AddSensorDataResponseContract
            {
                SensorData = response
            };
        }
        public async Task<SensorAppInfoContract> GetSensorAppInfo()
        {
            string subUrl = Address.UrlCombine(Address.SensorsAppInfo);
            var response = await GetRequest<SensorAppInfoContract>(subUrl);

            return response;
        }
        public async Task GetSensorAppFile()
        {
            //string subUrl = Address.SensorsAppFile;
            //var response = await GetRequest<SensorAppInfoContract>(subUrl);

            //return response;
            await Task.CompletedTask;
        }
    }
}
