using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<ShiftContract[]> GetShifts(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Shifts, queryString);
            var response = await GetRequest<ShiftContract[]>(subUrl);

            return response;
        }

        public async Task<ShiftContract> GetShift(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Shifts, Convert.ToString(id), queryString);
            var response = await GetRequest<ShiftContract>(subUrl);

            return response;
        }

        public async Task<ShiftContract> AddShift(ShiftContract shiftContract)
        {
            string subUrl = Address.UrlCombine(Address.Shifts);
            var response = await PostRequest<AddShiftResponseContract>(subUrl, shiftContract);

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return (ShiftContract)response;
        }

        public async Task UpdateShift(ShiftContract shiftContract)
        {
            if (shiftContract.Id == 0)
            {
                throw new BadRequestException(NotFoundException.message + " Shift object has no Id.");
            }
            string subUrl = Address.UrlCombine(Address.Shifts, Convert.ToString(shiftContract.Id));
            await PatchRequest<string>(subUrl, shiftContract);
        }

        public async Task DeleteShift(int id)
        {
            string subUrl = Address.UrlCombine(Address.Shifts, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }
    }
}
