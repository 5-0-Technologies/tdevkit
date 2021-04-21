using SDK;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using SDK.Communication;
using SDK.Exceptions;
using SDK.Contracts.Data;
using SDK.Contracts.Communication;

namespace tDevkit
{

    public class DevkitConnectorV3 : DevkitConnector
    {
        private ConnectionOptions connectionOptions;
        protected HttpClient httpClient;
        private string baseAddress;

        public DevkitConnectorV3(ConnectionOptions connectionOptions) : this(connectionOptions, new HttpClient())
        {
        }
        public DevkitConnectorV3(ConnectionOptions connectionOptions, HttpClient httpClient)
        {
            this.connectionOptions = connectionOptions;
            this.httpClient = httpClient;
            baseAddress = connectionOptions.Url + "/" + connectionOptions.Version + "/";

            resetHttpClientHeaders();
        }

        private void resetHttpClientHeaders()
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Client", connectionOptions.ClientGuid);
            httpClient.DefaultRequestHeaders.Add("Branch", connectionOptions.BranchGuid);
            httpClient.DefaultRequestHeaders.Add("Token", connectionOptions.Token);
            httpClient.DefaultRequestHeaders.Add("Api-Key", connectionOptions.ApiKey);
        }

        #region REQUESTS
        private async Task<Type> GetRequest<Type>(string subUrl)
        {
            var task = await SendGetRequest(subUrl);

            string responseString = await ProcessResponse(task);
            return JsonSerializer.Deserialize<Type>(responseString);
        }
        private async Task<Type> PostRequest<Type>(string subUrl, object body)
        {
            string bodyContent = JsonSerializer.Serialize(body);
            var task = await SendPostRequest(subUrl, bodyContent);

            string responseString = await ProcessResponse(task);
            return JsonSerializer.Deserialize<Type>(responseString);
        }
        private async Task<Type> PatchRequest<Type>(string subUrl, object body)
        {
            string bodyContent = JsonSerializer.Serialize(body);
            var task = await SendPatchRequest(subUrl, bodyContent);

            string responseString = await ProcessResponse(task);
            return JsonSerializer.Deserialize<Type>(responseString);
        }
        private async Task<HttpResponseMessage> DeleteRequest(string subUrl)
        {
            var task = await SendDeleteRequest(subUrl);

            string responseString = await ProcessResponse(task);

            if (responseString == "")
            {
                return new HttpResponseMessage();
            }
            return JsonSerializer.Deserialize<HttpResponseMessage>(responseString);
        }
        #endregion

        #region SEND REQUESTS
        private async Task<HttpResponseMessage> SendGetRequest(string subUrl)
        {
            var task = await httpClient.GetAsync(baseAddress + subUrl);

            return task;
        }
        private async Task<HttpResponseMessage> SendPostRequest(string subUrl, string bodyContent)
        {
            HttpContent httpContent = new StringContent(bodyContent, Encoding.UTF8, "application/json");
            var task = await httpClient.PostAsync(baseAddress + subUrl, httpContent);

            return task;
        }
        private async Task<HttpResponseMessage> SendPatchRequest(string subUrl, string bodyContent)
        {
            HttpContent httpContent = new StringContent(bodyContent, Encoding.UTF8, "application/json");
            var task = await httpClient.PatchAsync(baseAddress + subUrl, httpContent);

            return task;
        }
        private async Task<HttpResponseMessage> SendDeleteRequest(string subUrl)
        {
            var task = await httpClient.DeleteAsync(baseAddress + subUrl);

            return task;
        }
        #endregion

        private async Task<string> ProcessResponse(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();

            switch (response.StatusCode)
            {
                case (System.Net.HttpStatusCode)400:
                    var responseA = JsonSerializer.Deserialize<ServerErrorResponseContract>(responseString);
                    throw new BadRequestException(BadRequestException.message + " " + responseA.Message);
                case (System.Net.HttpStatusCode)401:
                    throw new NotAuthorizedException(NotAuthorizedException.message);
                case (System.Net.HttpStatusCode)404:
                    var responseB = JsonSerializer.Deserialize<ServerErrorResponseContract>(responseString);
                    throw new NotFoundException(NotFoundException.message + " " + responseB.Message);
                case (System.Net.HttpStatusCode)500:
                    throw new InternalServerErrorException(InternalServerErrorException.message);
            }

            return responseString;
        }

        #region AOS (0/13)
        #endregion

        #region AREAS (2/2)
        public async Task<AreaContract[]> GetAreas()
        {
            string subUrl = Address.Areas;
            var response = await GetRequest<AreaContract[]>(subUrl);

            return response;
        }
        public async Task<AreaContract> GetArea(int id)
        {
            string subUrl = Address.Areas + id;
            var response = await GetRequest<AreaContract>(subUrl);

            return response;
        }
        #endregion

        #region AUTHORIZATION (2/3)
        public async Task<HttpResponseMessage> DeleteCurrentToken()
        {
            string subUrl = Address.AuthorizationToken;

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Token", connectionOptions.Token);

            var response = await DeleteRequest(subUrl);

            resetHttpClientHeaders();

            return response;
        }
        public async Task<HttpResponseMessage> GetToken()
        {
            string url = Address.AuthorizationToken;

            var task = await SendGetRequest(url);

            if (task.IsSuccessStatusCode)
            {
                var responseString = await task.Content.ReadAsStringAsync();

                AuthenticationResponseContract response = JsonSerializer.Deserialize<AuthenticationResponseContract>(responseString);

                connectionOptions.Token = response.Token;
                httpClient.DefaultRequestHeaders.Add("Token", connectionOptions.Token);
            }

            return task;

        }
        public async Task<AuthenticationResponseContract> Authenticate(bool superUser)
        {
            return await Authenticate(connectionOptions.Login, connectionOptions.Password, superUser);
        }
        public async Task<AuthenticationResponseContract> Authenticate(string login, string password, bool superUser)
        {
            string subUrl = Address.AuthorizationAuthenticate;

            CredentialContract credentialContract = new CredentialContract
            {
                Login = login,
                Password = password
            };


            if (!superUser)
                credentialContract.Client = connectionOptions.Client;

            var response = await PostRequest<AuthenticationResponseContract>(subUrl, credentialContract);

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            connectionOptions.Token = response.Token;
            if (response.Client != null)
                connectionOptions.ClientGuid = response.Client;
            if (response.Branch != null)
                connectionOptions.BranchGuid = response.Branch;

            resetHttpClientHeaders();

            return response;
        }
        #endregion

        #region BEACONS (5/5)

        public async Task<BeaconContract[]> GetBeacons()
        {
            string subUrl = Address.Beacons;
            var response = await GetRequest<BeaconContract[]>(subUrl);

            return response;
        }
        public async Task<BeaconContract> AddBeacon(BeaconContract beaconContract)
        {
            string subUrl = Address.Beacons;
            var response = await PostRequest<AddBeaconResponseContract>(subUrl, beaconContract);

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            return (BeaconContract)response;
        }
        public async Task<HttpResponseMessage> DeleteBeacon(int id)
        {
            string subUrl = Address.Beacons + id;
            var response = await DeleteRequest(subUrl);

            return response;
        }
        public async Task<BeaconContract> GetBeacon(int id)
        {
            string subUrl = Address.Beacons + id;
            var response = await GetRequest<BeaconContract>(subUrl);

            return response;
        }
        public async Task<AddBeaconResponseContract> UpdateBeacon(BeaconContract beaconContract)
        {
            if (beaconContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Beacon object has no Id.");
            }
            string subUrl = Address.Beacons + beaconContract.Id;
            var response = await PatchRequest<AddBeaconResponseContract>(subUrl, beaconContract);

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            return response;
        }
        #endregion

        #region BRANCHES (2/2)
        public async Task<BranchContract[]> GetBranches(string queryString = "")
        {
            string subUrl = Address.Branches + queryString;
            var response = await GetRequest<BranchContract[]>(subUrl);

            return response;
        }
        public async Task<BranchContract> GetBranch(int id)
        {
            string subUrl = Address.Branches + id;
            var response = await GetRequest<BranchContract>(subUrl);

            return response;
        }
        #endregion

        #region CLIENTS (1/1)
        public async Task<ClientContract[]> GetClients()
        {
            string subUrl = Address.Clients;
            var response = await GetRequest<ClientContract[]>(subUrl);

            return response;
        }
        #endregion

        #region CONFIGURATION (3/3)
        public async Task<ConfigurationContract> GetBranchConfiguration(string key)
        {
            string subUrl = Address.ConfigurationBranch + key;

            var task = await SendGetRequest(subUrl);

            var responseString = await ProcessResponse(task);
            ConfigurationContract response = new ConfigurationContract
            {
                Value = responseString
            };

            return response;
        }
        public async Task<ConfigurationContract> GetAccountConfiguration(string key)
        {
            string subUrl = Address.ConfigurationAccount + key;

            var task = await SendGetRequest(subUrl);

            var responseString = await ProcessResponse(task);
            ConfigurationContract response = new ConfigurationContract
            {
                Value = responseString
            };

            return response;
        }
        public async Task<long> GetConfigurationLastChange(string key)
        {
            string subUrl = Address.Configuration + key + "/last-change/";

            var task = await SendGetRequest(subUrl);

            var responseString = await ProcessResponse(task);

            return Convert.ToInt64(responseString);
        }
        #endregion

        #region DEVICES (5/6)
        public async Task<DeviceContract[]> GetDevices()
        {
            string subUrl = Address.Devices;
            var response = await GetRequest<DeviceContract[]>(subUrl);

            return response;
        }
        public async Task<DeviceContract> GetDevice(int id)
        {
            string subUrl = Address.Devices + id;
            var response = await GetRequest<DeviceContract>(subUrl);

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
        public async Task<HttpResponseMessage> AddDevice()
        {
            return null;
        }
        #endregion

        #region LAYERS (2/2)
        public async Task<LayerContract[]> GetLayers()
        {
            string subUrl = Address.Layers;
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }
        public async Task<LayerContract> GetLayer(int id)
        {
            string subUrl = Address.Layers + id;
            var response = await GetRequest<LayerContract>(subUrl);

            return response;
        }
        #endregion

        #region LOCALIZATION (2/2)
        public async Task<PostResponseContract[]> AddLocalizationData(DeviceLocationContract[] deviceLocationContract)
        {
            string subUrl = Address.LocalizationAddDataBatch;
            var response = await PostRequest<AddLocatizationDataResponseContract[]>(subUrl, deviceLocationContract);

            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].Locations != null)
                    for (int j = 0; j < response[i].Locations.Count; j++)
                    {
                        var dataResult = response[i].Locations[j];
                        if (dataResult.ErrorMessage != null)
                        {
                            throw new ServerResponseException(ServerResponseException.message + dataResult.ErrorMessage);
                        }
                    }
                if (response[i].ErrorMessage != null)
                    throw new ServerResponseException(ServerResponseException.message + " " + response[i].ErrorMessage);
            }

            return response;
        }
        public async Task<PostResponseContract[]> AddLocalizationData(LocationContract[] locationContract)
        {
            string subUrl = Address.LocalizationAddData;
            var response = await PostRequest<AddLocatizationDataResponseContract[]>(subUrl, locationContract);

            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].Locations != null)
                    for (int j = 0; j < response[i].Locations.Count; j++)
                    {
                        var dataResult = response[i].Locations[j];
                        if (dataResult.ErrorMessage != null)
                        {
                            throw new ServerResponseException(ServerResponseException.message + dataResult.ErrorMessage);
                        }
                    }
                if (response[i].ErrorMessage != null)
                    throw new ServerResponseException(ServerResponseException.message + " " + response[i].ErrorMessage);
            }

            return response;
        }
        #endregion

        #region SECTORS (2/2)
        public async Task<SectorContract[]> GetSectors()
        {
            string subUrl = Address.Sectors;
            var response = await GetRequest<SectorContract[]>(subUrl);

            return response;
        }
        public async Task<SectorContract> GetSector(int id)
        {
            string subUrl = Address.Sectors + id;
            var response = await GetRequest<SectorContract>(subUrl);

            return response;
        }
        #endregion

        #region SENSORS (4/5)
        public async Task<SensorContract[]> GetSensors()
        {
            string subUrl = Address.Sensors;
            var response = await GetRequest<SensorContract[]>(subUrl);

            return response;
        }
        public async void GetSensorAppFile()
        {
            //string subUrl = Address.SensorsAppFile;
            //var response = await GetRequest<SensorAppInfoContract>(subUrl);

            //return response;
        }
        public async Task<SensorAppInfoContract> GetSensorAppInfo()
        {
            string subUrl = Address.SensorsAppInfo;
            var response = await GetRequest<SensorAppInfoContract>(subUrl);

            return response;
        }
        public async Task<PostResponseContract[]> AddSensorData(SensorContract[] sensors)
        {
            string subUrl = Address.SensorsAddDataBatch;
            var response = await PostRequest<AddSensorDataResponseContract[]>(subUrl, sensors);


            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].SensorData != null)
                    for (int j = 0; j < response[i].SensorData.Count; j++)
                    {
                        var sensorDataResult = response[i].SensorData[j];
                        if (sensorDataResult.ErrorMessage != null)
                        {
                            throw new ServerResponseException(ServerResponseException.message +
                                " Quantity: " + sensorDataResult.Quantity + " - " + sensorDataResult.ErrorMessage);
                        }
                    }
                if (response[i].ErrorMessage != null)
                    throw new ServerResponseException(ServerResponseException.message + " " + response[i].ErrorMessage);
            }

            return response;
        }
        public async Task<PostResponseContract> AddSensorData(SensorDataContract[] sensorData)
        {
            string subUrl = Address.SensorsAddData;
            var response = await PostRequest<AddSensorDataResponseContract>(subUrl, sensorData);

            if (response.SensorData != null)
                for (int i = 0; i < response.SensorData.Count; i++)
                {
                    var sensorDataResult = response.SensorData[i];
                    if (sensorDataResult.ErrorMessage != null)
                    {
                        throw new ServerResponseException(ServerResponseException.message +
                            " Quantity: " + sensorDataResult.Quantity + " - " + sensorDataResult.ErrorMessage);
                    }
                }

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            return response;
        }
        #endregion

        #region USERS (1/1)
        public async Task<UserContract> GetUserInfo()
        {
            string subUrl = Address.Users;
            var response = await GetRequest<UserContract>(subUrl);

            return response;
        }
        #endregion
    }
}
