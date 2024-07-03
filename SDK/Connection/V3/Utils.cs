
using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(5/5)
    public partial class DevkitConnectorV3
    {
        public async Task<FileInfoContract[]> GetDemoFilesInfo()
        {
            string subUrl = Address.UrlCombine(Address.UtilsDemoFilesInfo);
            var response = await GetRequest<FileInfoContract[]>(subUrl);

            return response;
        }

        public async Task<byte[]> GetFile(string fileName)
        {
            string subUrl = Address.UrlCombine(Address.UtilsFile, fileName);

            return await GetFile(fileName, subUrl);
        }

        public async Task<byte[]> GetDemoFile(string fileName)
        {
            string subUrl = Address.UrlCombine(Address.UtilsDemoFile, fileName);
            //File.WriteAllBytes("C:\\Users\\mondr\\source\\repos\\twinzo-sdk\\bytes.jpg", bytes);
            return await GetFile(fileName, subUrl);
        }

        private async Task<byte[]> GetFile(string fileName, string subUrl)
        {
            var response = await httpClient.GetAsync(subUrl);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<string> GetUnityLastVersion(string platform)
        {
            string subUrl = Address.UrlCombine(Address.UtilsUnityLastVersion, platform);
            var response = await GetRequest<string>(subUrl);

            return response;
        }

        public async Task<FileInfoContract> GetUnityBundleInfo(string bundleName)
        {
            string subUrl = Address.UrlCombine(Address.UtilsUnityBundleInfo, bundleName);
            var response = await GetRequest<FileInfoContract>(subUrl);

            return response;
        }

        /// <summary>
        /// Generic GET request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subUrl"></param>
        /// <returns></returns>
        public async Task<T> Get<T>(string subUrl)
        {
            var response = await GetRequest<T>(subUrl);

            return response;
        }

        /// <summary>
        /// Generic POST request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subUrl"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<T> Post<T>(string subUrl, object body)
        {
            var response = await PostRequest<T>(subUrl, body);

            return response;
        }

        /// <summary>
        /// Generic PATCH request
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="subUrl"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task<T> Patch<T>(string subUrl, object body)
        {
            var response = await PatchRequest<T>(subUrl, body);

            return response;
        }

        /// <summary>
        /// Generic DELETE request
        /// </summary>
        /// <param name="subUrl"></param>
        /// <returns></returns>
        public async Task Delete(string subUrl)
        {
            await DeleteRequest(subUrl);
        }
    }
}
