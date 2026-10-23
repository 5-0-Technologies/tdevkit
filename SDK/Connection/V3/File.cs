using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<byte[]> GetPlatformFile(string fileName)
        {
            return await GetBytes(Address.UrlCombine(Address.File, fileName));
        }

        public async Task<FileContract> GetPlatformFileInfo(string fileName)
        {
            return await GetRequest<FileContract>(Address.UrlCombine(Address.FileInfo, fileName));
        }

        public async Task<byte[]> GetLogo()
        {
            return await GetBytes(Address.FileLogo);
        }

        public async Task<byte[]> GetAreaImage(Guid areaGuid)
        {
            return await GetBytes(Address.UrlCombine(Address.FileAreaImage, areaGuid.ToString()));
        }

        public async Task PostAreaImage(Guid areaGuid, byte[] content)
        {
            var httpContent = new System.Net.Http.ByteArrayContent(content);
            var response = await httpClient.PostAsync(Address.UrlCombine(Address.FileAreaImage, areaGuid.ToString()), httpContent);
            await EmptyResponse(response);
        }

        public async Task<FileContract> GetTviewerBundleInfo(string platform)
        {
            return await GetRequest<FileContract>(Address.UrlCombine(Address.FileTviewerBundleInfo, platform));
        }

        public async Task<FileContract[]> GetTviewerBundleInfoBatch(string platform)
        {
            return await GetRequest<FileContract[]>(Address.UrlCombine(Address.FileTviewerBundleInfo, platform, "batch"));
        }

        public async Task<byte[]> GetTviewerBundle(string platform)
        {
            return await GetBytes(Address.UrlCombine(Address.FileTviewerBundle, platform));
        }

        public async Task PostTviewerBundle(string platform, byte[] content)
        {
            var httpContent = new System.Net.Http.ByteArrayContent(content);
            var response = await httpClient.PostAsync(Address.UrlCombine(Address.FileTviewerBundle, platform), httpContent);
            await EmptyResponse(response);
        }

        public async Task<byte[]> GetTviewerThumbnail()
        {
            return await GetBytes(Address.FileTviewerThumbnail);
        }

        public async Task<FileContract> GetTviewerThumbnailInfo()
        {
            return await GetRequest<FileContract>(Address.FileTviewerThumbnailInfo);
        }

        public async Task<FileContract[]> GetTviewerThumbnailInfos()
        {
            return await GetRequest<FileContract[]>(Address.FileTviewerThumbnailInfos);
        }

        public async Task<FileContract[]> GetTviewerThumbnailInfoBatch()
        {
            return await GetRequest<FileContract[]>(Address.UrlCombine(Address.FileTviewerThumbnailInfo, "batch"));
        }

        public async Task PostTviewerBundleThumbnail(byte[] content)
        {
            var httpContent = new System.Net.Http.ByteArrayContent(content);
            var response = await httpClient.PostAsync(Address.UrlCombine(Address.File, "tviewer-bundle-thumbnail"), httpContent);
            await EmptyResponse(response);
        }

        public async Task PostTmindMd(object body)
        {
            await PostRequest(Address.FileTmindMd, body);
        }

        public async Task<byte[]> GetModeljobRawModel(int id)
        {
            return await GetBytes(Address.UrlCombine(Address.FileModeljobRawModel, id.ToString()));
        }

        private async Task<byte[]> GetBytes(string subUrl)
        {
            var response = await httpClient.GetAsync(subUrl);
            if (EnsureSuccessStatusCode && !response.IsSuccessStatusCode)
                await HandleError(response);
            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
