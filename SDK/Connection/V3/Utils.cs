using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    //(5/5)
    public partial class DevkitConnectorV3
    {
        public async Task<FileInfoContract[]> GetDemoFilesInfo()
        {
            string subUrl = Address.UtilsDemoFilesInfo;
            var response = await GetRequest<FileInfoContract[]>(subUrl);

            return response;
        }
        public async Task<byte[]> GetFile(string fileName)
        {
            string subUrl = Address.UtilsFile + fileName;

            return await GetFile(fileName, subUrl);
        }
        public async Task<byte[]> GetDemoFile(string fileName)
        {
            string subUrl = Address.UtilsDemoFile + fileName;
            //File.WriteAllBytes("C:\\Users\\mondr\\source\\repos\\twinzo-sdk\\bytes.jpg", bytes);
            return await GetFile(fileName, subUrl);
        }
        private async Task<byte[]> GetFile(string fileName, string subUrl)
        {
            var task = await SendGetRequest(subUrl);

            string responseString = await ProcessResponse(task);
            return Encoding.UTF8.GetBytes(responseString);
        }
        public async Task<string> GetUnityLastVersion(string platform)
        {
            string subUrl = Address.UtilsUnityLastVersion + platform;
            var response = await GetRequest<string>(subUrl);

            return response;
        }
        public async Task<FileInfoContract> GetUnityBundleInfo(string bundleName)
        {
            string subUrl = Address.UtilsUnityBundleInfo + bundleName;
            var response = await GetRequest<FileInfoContract>(subUrl);

            return response;
        }
    }
}
