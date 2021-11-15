using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SDK
{
    //(4/5)
    public partial class DevkitConnectorV3
    {
        public async Task<SectorContract[]> GetSectors(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Sectors, queryString);
            var response = await GetRequest<SectorContract[]>(subUrl);

            return response;
        }
        public async Task<SectorContract> GetSector(int id, string queryString = "")
        {
            string subUrl = UrlCombine(Address.Sectors, Convert.ToString(id), queryString);
            var response = await GetRequest<SectorContract>(subUrl);

            return response;
        }
        public async Task<SectorContract> AddSector(SectorContract sectorContract)
        {
            string subUrl = UrlCombine(Address.Sectors);
            var response = await PostRequest<AddSectorResponseContract>(subUrl, sectorContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return (SectorContract)response;
        }
        public async Task<PatchResponseContract> UpdateSector(SectorContract sectorContract)
        {
            if (sectorContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Sector object has no Id.");
            }
            string subUrl = UrlCombine(Address.Sectors, Convert.ToString(sectorContract.Id));
            var response = await PatchRequest(subUrl, sectorContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return response;
        }
        public async Task<HttpResponseMessage> DeleteSector(int id)
        {
            string subUrl = UrlCombine(Address.Sectors, Convert.ToString(id));
            var response = await DeleteRequest(subUrl);

            return response;
        }
    }
}
