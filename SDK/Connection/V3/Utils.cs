using SDK.Contracts.Data;
using SDK.Models;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    //(5/5)
    public partial class DevkitConnectorV3
    {
        public async Task<FileInfoContract[]> GetDemoFilesInfo()
        {
            string subUrl = UrlCombine(Address.UtilsDemoFilesInfo);
            var response = await GetRequest<FileInfoContract[]>(subUrl);

            return response;
        }

        public async Task<byte[]> GetFile(string fileName)
        {
            string subUrl = UrlCombine(Address.UtilsFile, fileName);

            return await GetFile(fileName, subUrl);
        }

        public async Task<byte[]> GetDemoFile(string fileName)
        {
            string subUrl = UrlCombine(Address.UtilsDemoFile, fileName);
            return await GetFile(fileName, subUrl);
        }

        private async Task<byte[]> GetFile(string fileName, string subUrl)
        {
            var response = await httpClient.GetAsync(subUrl);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<string> GetUnityLastVersion(string platform)
        {
            string subUrl = UrlCombine(Address.UtilsUnityLastVersion, platform);
            var response = await GetRequest<string>(subUrl);

            return response;
        }

        public async Task<FileInfoContract> GetUnityBundleInfo(string bundleName)
        {
            string subUrl = UrlCombine(Address.UtilsUnityBundleInfo, bundleName);
            var response = await GetRequest<FileInfoContract>(subUrl);

            return response;
        }
    }
}
