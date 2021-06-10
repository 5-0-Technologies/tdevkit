using SDK.Communication;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<PostResponseContract[]> AddLocalizationData(DeviceLocationContract[] deviceLocationContract)
        {
            string subUrl = Address.LocalizationAddDataBatch;
            var response = await PostRequest<AddLocatizationDataResponseContract[]>(subUrl, deviceLocationContract);

            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].Locations != null)
                    for (int j = 0; j < response[i].Locations.Count; j++)
                    {
                        var dataResult = response[i].Locations[j];
                        if (dataResult.ErrorMessage != null)
                        {
                            throw new ServerResponseException(ServerResponseException.message + dataResult.ErrorMessage);
                        }
                    }
                if (response[i].ErrorMessage != null)
                    throw new ServerResponseException(ServerResponseException.message + " " + response[i].ErrorMessage);
            }

            return response;
        }
        public async Task<PostResponseContract[]> AddLocalizationData(LocationContract[] locationContract)
        {
            string subUrl = Address.LocalizationAddData;
            var response = await PostRequest<AddLocatizationDataResponseContract[]>(subUrl, locationContract);

            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].Locations != null)
                    for (int j = 0; j < response[i].Locations.Count; j++)
                    {
                        var dataResult = response[i].Locations[j];
                        if (dataResult.ErrorMessage != null)
                        {
                            throw new ServerResponseException(ServerResponseException.message + dataResult.ErrorMessage);
                        }
                    }
                if (response[i].ErrorMessage != null)
                    throw new ServerResponseException(ServerResponseException.message + " " + response[i].ErrorMessage);
            }

            return response;
        }
    }
}
