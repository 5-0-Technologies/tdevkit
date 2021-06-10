using SDK.Contracts.Communication;
using SDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using tDevkit;

namespace tDevkit
{
    public partial class DevkitConnectorV3
    {
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
        private async Task<PatchResponseContract> PatchRequest(string subUrl, object body)
        {
            string bodyContent = JsonSerializer.Serialize(body);
            var task = await SendPatchRequest(subUrl, bodyContent);

            string responseString = await ProcessResponse(task);
            return new PatchResponseContract();
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
                    ServerErrorResponseContract responseB;
                    try
                    {
                        responseB = JsonSerializer.Deserialize<ServerErrorResponseContract>(responseString);
                    }
                    catch (JsonException)
                    {
                        throw new NotFoundException(NotFoundException.message);
                    }
                    throw new NotFoundException(NotFoundException.message + " " + responseB.Message);
                case (System.Net.HttpStatusCode)500:
                    throw new InternalServerErrorException(InternalServerErrorException.message);
            }

            return responseString;
        }
    }
}
