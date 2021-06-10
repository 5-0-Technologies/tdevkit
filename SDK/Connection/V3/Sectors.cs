using SDK.Contracts.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    //(4/4)
    public partial class DevkitConnectorV3
    {
        public async Task<SectorContract[]> GetSectors()
        {
            string subUrl = Address.Sectors;
            var response = await GetRequest<SectorContract[]>(subUrl);

            return response;
        }
        public async Task<SectorContract> AddSector(SectorContract sectorContract)
        {
            string subUrl = Address.Sectors;
            var response = await PostRequest<AddSectorResponseContract>(subUrl, sectorContract);

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            return (SectorContract)response;
        }
        public async Task<SectorContract> GetSector(int id)
        {
            string subUrl = Address.Sectors + id;
            var response = await GetRequest<SectorContract>(subUrl);

            return response;
        }
        public async Task<PatchResponseContract> UpdateSector(SectorContract sectorContract)
        {
            if (sectorContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Sector object has no Id.");
            }
            string subUrl = Address.Sectors + sectorContract.Id;
            var response = await PatchRequest(subUrl, sectorContract);

            if (response.ErrorMessage != null)
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);

            return response;
        }
    }
}
