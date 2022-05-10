using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
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

        public async Task<SectorContract> AddSector(SectorContract sectorContract)
        {
            string subUrl = Address.UrlCombine(Address.Sectors);
            var response = await PostRequest<AddSectorResponseContract>(subUrl, sectorContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return (SectorContract)response;
        }

        public async Task UpdateSector(SectorContract sectorContract)
        {
            if (sectorContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Sector object has no Id.");
            }
            string subUrl = Address.UrlCombine(Address.Sectors, Convert.ToString(sectorContract.Id));
            await PatchRequest<string>(subUrl, sectorContract);
        }

        public async Task DeleteSector(int id)
        {
            string subUrl = Address.UrlCombine(Address.Sectors, Convert.ToString(id));
            await DeleteRequest<string>(subUrl);
        }
    }
}
