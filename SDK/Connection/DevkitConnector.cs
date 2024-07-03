using SDK.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SDK
{
    public static class HttpHeaders
    {
        public static string BRANCH { get; } = "Branch";
        public static string CLIENT { get; } = "Client";
        public static string TOKEN { get; } = "Token";
        public static string APIKEY { get; } = "Api-Key";
        public static string MAINAPIKEY { get; } = "mApi-Key";
    }

    public abstract class DevkitConnector
    {

        protected readonly ConnectionOptions connectionOptions;
        protected HttpClient httpClient;

        public bool EnsureSuccessStatusCode { get; set; } = true;

        public DevkitConnector(ConnectionOptions connectionOptions) : this(connectionOptions, new HttpClient())
        {
        }

        public DevkitConnector(ConnectionOptions connectionOptions, HttpClient httpClient)
        {
            this.connectionOptions = connectionOptions;
            this.httpClient = httpClient;
            this.httpClient.DefaultRequestVersion = HttpVersion.Version30;
            httpClient.BaseAddress = new Uri(connectionOptions.Url + "/" + connectionOptions.Version + "/");

            ResetHttpClientHeaders();
        }

        #region REQUESTS
        protected async Task<Type> GetRequest<Type>(string subUrl)
        {
            var response = await httpClient.GetAsync(subUrl);
            return await JsonResponse<Type>(response);
        }

        protected async Task<Type> PostRequest<Type>(string subUrl, object body)
        {
            string bodyContent = JsonSerializer.Serialize(body);
            HttpContent httpContent = new StringContent(bodyContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(subUrl, httpContent);
            return await JsonResponse<Type>(response);
        }

        protected async Task<Type> PatchRequest<Type>(string subUrl, object body)
        {
            string bodyContent = JsonSerializer.Serialize(body);
            HttpContent httpContent = new StringContent(bodyContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PatchAsync(subUrl, httpContent);
            return await JsonResponse<Type>(response);
        }

        protected async Task PatchRequest(string subUrl, object body)
        {
            string bodyContent = JsonSerializer.Serialize(body);
            HttpContent httpContent = new StringContent(bodyContent, Encoding.UTF8, "application/json");
            var response = await httpClient.PatchAsync(subUrl, httpContent);
            await EmptyResponse(response);
        }

        protected async Task<Type> DeleteRequest<Type>(string subUrl)
        {
            var response = await httpClient.DeleteAsync(subUrl);
            return await JsonResponse<Type>(response);
        }

        protected async Task DeleteRequest(string subUrl)
        {
            var response = await httpClient.DeleteAsync(subUrl);
            await EmptyResponse(response);
        }
        #endregion

        protected async Task<Type> JsonResponse<Type>(HttpResponseMessage response)
        {
            if (EnsureSuccessStatusCode)
            {
                if (!response.IsSuccessStatusCode)
                    await HandleError(response);
            }
            else
            {
                if (!response.IsSuccessStatusCode)
                    return default;
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Type>(jsonString);
        }

        protected async Task EmptyResponse(HttpResponseMessage response)
        {
            if (EnsureSuccessStatusCode)
                if (!response.IsSuccessStatusCode)
                    await HandleError(response);
        }

        protected async Task HandleError(HttpResponseMessage response)
        {
            var stringContent = await response.Content.ReadAsStringAsync();

            throw response.StatusCode switch
            {
                _ => throw new ServerResponseException(response.StatusCode + stringContent),
            };
        }

        #region HEADERS
        protected void ResetHttpClientHeaders()
        {
            httpClient.DefaultRequestHeaders.Clear();
            if (connectionOptions.ClientGuid != null) SetHeader(HttpHeaders.CLIENT, connectionOptions.ClientGuid);
            if (connectionOptions.BranchGuid != null) SetHeader(HttpHeaders.BRANCH, connectionOptions.BranchGuid);
            if (connectionOptions.Token != null) SetHeader(HttpHeaders.TOKEN, connectionOptions.Token);
            if (connectionOptions.ApiKey != null) SetHeader(HttpHeaders.APIKEY, connectionOptions.ApiKey);
            if (connectionOptions.MainApiKey != null) SetHeader(HttpHeaders.MAINAPIKEY, connectionOptions.MainApiKey);
        }

        public void ChangeClientGuid(string value)
        {
            ChangeHeader(HttpHeaders.CLIENT, value);
        }
        public void ChangeClientGuid(Guid value)
        {
            ChangeHeader(HttpHeaders.CLIENT, value.ToString());
        }
        public void ChangeBranchGuid(string value)
        {
            ChangeHeader(HttpHeaders.BRANCH, value);
        }
        public void ChangeBranchGuid(Guid value)
        {
            ChangeHeader(HttpHeaders.BRANCH, value.ToString());
        }
        public void ChangeToken(string value)
        {
            ChangeHeader(HttpHeaders.TOKEN, value);
        }
        public void ChangeApiKey(string value)
        {
            ChangeHeader(HttpHeaders.APIKEY, value);
        }
        public void ChangeMainApiKey(string value)
        {
            ChangeHeader(HttpHeaders.MAINAPIKEY, value);
        }

        public void RemoveClientGuid()
        {
            RemoveHeader(HttpHeaders.CLIENT);
        }
        public void RemoveBranchGuid()
        {
            RemoveHeader(HttpHeaders.BRANCH);
        }
        public void RemoveToken()
        {
            RemoveHeader(HttpHeaders.TOKEN);
        }
        public void RemoveApiKey()
        {
            RemoveHeader(HttpHeaders.APIKEY);
        }
        public void RemoveMainApiKey()
        {
            RemoveHeader(HttpHeaders.MAINAPIKEY);
        }

        private void ChangeHeader(string header, string value)
        {
            RemoveHeader(header);
            SetHeader(header, value);
        }
        private void SetHeader(string header, string value)
        {
            httpClient.DefaultRequestHeaders.Add(header, value);
        }
        private void RemoveHeader(string header)
        {
            httpClient.DefaultRequestHeaders.Remove(header);
        }
        #endregion
    }
}
