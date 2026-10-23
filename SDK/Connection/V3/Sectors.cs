using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SDK
{
    //(4/5)
    public partial class DevkitConnectorV3
    {
        public async Task<SectorContract[]> GetSectors(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Sectors, queryString);
            var response = await GetRequest<SectorContract[]>(subUrl);

            return response;
        }
        public async Task<SectorContract> GetSector(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Sectors, Convert.ToString(id), queryString);
            var response = await GetRequest<SectorContract>(subUrl);

            return response;
        }

        public async Task<SectorContract> AddSector(SectorWriteContract sectorContract)
        {
            string subUrl = Address.UrlCombine(Address.Sectors);
            var response = await PostRequest<SectorContract>(subUrl, sectorContract);

            return response;
        }

        public async Task UpdateSector(int id, object changes)
        {
            string subUrl = Address.UrlCombine(Address.Sectors, id.ToString());
            await PatchRequest(subUrl, changes);
        }

        public async Task DeleteSector(int id)
        {
            string subUrl = Address.UrlCombine(Address.Sectors, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }

        public async Task<byte[]> GetSectorLayout(int sectorId)
        {
            string subUrl = Address.UrlCombine(Address.SectorsLayout, sectorId.ToString());
            var response = await httpClient.GetAsync(subUrl);
            if (EnsureSuccessStatusCode && !response.IsSuccessStatusCode)
                await HandleError(response);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<byte[]> GetSectorLayouts()
        {
            var response = await httpClient.GetAsync(Address.SectorsLayouts);
            if (EnsureSuccessStatusCode && !response.IsSuccessStatusCode)
                await HandleError(response);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task PostSectorLayout(int sectorId, string extension, byte[] content)
        {
            string subUrl = Address.UrlCombine(Address.SectorsLayout, sectorId.ToString(), extension);
            var httpContent = new System.Net.Http.ByteArrayContent(content);
            var response = await httpClient.PostAsync(subUrl, httpContent);
            await EmptyResponse(response);
        }

        public async Task PutSectorLayout(int sectorId, byte[] content)
        {
            string subUrl = Address.UrlCombine(Address.Sectors, sectorId.ToString(), "layout");
            var httpContent = new System.Net.Http.ByteArrayContent(content);
            var response = await httpClient.PutAsync(subUrl, httpContent);
            await EmptyResponse(response);
        }

        public async Task DeleteSectorLayout(int sectorId)
        {
            await DeleteRequest(Address.UrlCombine(Address.Sectors, sectorId.ToString(), "layout"));
        }
    }
}
