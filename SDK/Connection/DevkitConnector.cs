using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SDK
{
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
            httpClient.BaseAddress = new Uri(connectionOptions.Url + "/" + connectionOptions.Version + "/");

            ResetHttpClientHeaders();
        }

        protected string UrlCombine(params string[] items)
        {
            if (items?.Any() != true)
            {
                return string.Empty;
            }

            return string.Join("/", items.Where(u => !string.IsNullOrWhiteSpace(u)).Select(u => u.Trim('/', '\\')));
        }

        protected void ResetHttpClientHeaders()
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add("Client", connectionOptions.ClientGuid);
            httpClient.DefaultRequestHeaders.Add("Branch", connectionOptions.BranchGuid);
            httpClient.DefaultRequestHeaders.Add("Token", connectionOptions.Token);
            httpClient.DefaultRequestHeaders.Add("Api-Key", connectionOptions.ApiKey);
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
            EmptyResponse(response);
        }

        protected async Task<Type> DeleteRequest<Type>(string subUrl)
        {
            var response = await httpClient.DeleteAsync(subUrl);
            return await JsonResponse<Type>(response);
        }

        protected async Task DeleteRequest(string subUrl)
        {
            var response = await httpClient.DeleteAsync(subUrl);
            EmptyResponse(response);
        }
        #endregion

        protected async Task<Type> JsonResponse<Type>(HttpResponseMessage response)
        {
            if (EnsureSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
            }
            else
            {
                if (!response.IsSuccessStatusCode)
                    return default(Type);
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Type>(jsonString);
        }

        protected void EmptyResponse(HttpResponseMessage response)
        {
            if (EnsureSuccessStatusCode)
                response.EnsureSuccessStatusCode();
        }
    }
}
