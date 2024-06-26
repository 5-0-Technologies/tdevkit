﻿using SDK.Communication;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<PostResponseContract[]> AddLocalizationData(DeviceLocationContract[] deviceLocationContract)
        {
            string subUrl = Address.UrlCombine(Address.LocalizationAddDataBatch);
            var response = await PostRequest<AddLocatizationDataResponseContract[]>(subUrl, deviceLocationContract);

            for (int i = 0; i < response.Length; i++)
            {
                if (response[i].Locations != null)
                {
                    for (int j = 0; j < response[i].Locations.Count; j++)
                    {
                        var dataResult = response[i].Locations[j];
                        if (dataResult.ErrorMessage != null)
                        {
                            throw new ServerResponseException(ServerResponseException.message + dataResult.ErrorMessage);
                        }
                    }
                }

                if (response[i].ErrorMessage != null)
                {
                    throw new ServerResponseException(ServerResponseException.message + " " + response[i].ErrorMessage);
                }
            }

            return response;
        }
        public async Task<PostResponseContract> AddLocalizationData(LocationContract[] locationContract)
        {
            string subUrl = Address.UrlCombine(Address.LocalizationAddData);
            var response = await PostRequest<AddLocatizationDataResponseContract>(subUrl, locationContract);


            if (response.Locations != null)
            {
                for (int i = 0; i < response.Locations.Count; i++)
                {
                    var dataResult = response.Locations[i];
                    if (dataResult.ErrorMessage != null)
                    {
                        throw new ServerResponseException(ServerResponseException.message + dataResult.ErrorMessage);
                    }
                }
            }

            if (response.ErrorMessage != null)
            {
                throw new ServerResponseException(ServerResponseException.message + " " + response.ErrorMessage);
            }

            return response;
        }
    }
}
