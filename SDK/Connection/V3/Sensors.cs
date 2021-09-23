using SDK.Communication;
using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace tDevkit
{
    //(9/10)
    public partial class DevkitConnectorV3
    {
        public async Task<SensorContract[]> GetSensors(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Sensors, queryString);
            var response = await GetRequest<SensorContract[]>(subUrl);

            return response;
        }
        public async Task<SensorContract> GetSensor(int id, string queryString = "")
        {
            string subUrl = UrlCombine(Address.Sensors, Convert.ToString(id), queryString);
            var response = await GetRequest<SensorContract>(subUrl);

            return response;
        }
        public async Task<SensorContract> GetSensor(string login, string queryString = "")
        {
            string subUrl = UrlCombine(Address.SensorsLogin, login, queryString);
            var response = await GetRequest<SensorContract>(subUrl);

            return response;
        }
        public async Task<SensorContract> AddSensor(SensorContract sensorContract)
        {
            string subUrl = Address.Sensors;
            var response = await PostRequest<AddSensorResponseContract>(subUrl, sensorContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return (SensorContract)response;
        }
        public async Task<PatchResponseContract> UpdateSensor(SensorContract sensorContract)
        {
            if (sensorContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Sensor object has no Id.");
            }
            string subUrl = Address.Sensors + sensorContract.Id;
            var response = await PatchRequest(subUrl, sensorContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return response;
        }
        public async Task<HttpResponseMessage> DeleteSensor(int id)
        {
            string subUrl = Address.Sensors + id;
            var response = await DeleteRequest(subUrl);

            return response;
        }
        public async Task<PostResponseContract[]> AddSensorData(SensorContract[] sensors)
        {
            string subUrl = Address.SensorsAddDataBatch;
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
        public async Task<PostResponseContract> AddSensorData(SensorDataContract[] sensorData)
        {
            string subUrl = Address.SensorsAddData;
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

            return new AddSensorDataResponseContract {
                SensorData = response
            };
        }
        public async Task<SensorAppInfoContract> GetSensorAppInfo()
        {
            string subUrl = Address.SensorsAppInfo;
            var response = await GetRequest<SensorAppInfoContract>(subUrl);

            return response;
        }
        public async void GetSensorAppFile()
        {
            //string subUrl = Address.SensorsAppFile;
            //var response = await GetRequest<SensorAppInfoContract>(subUrl);

            //return response;
        }
    }
}
