﻿using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace tDevkit
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<LayerContract[]> GetLayers(string queryString = "")
        {
            string subUrl = UrlCombine(Address.Layers, queryString);
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }

        public async Task<LayerContract> GetLayer(int id, string queryString = "")
        {
            string subUrl = UrlCombine(Address.Layers, Convert.ToString(id), queryString);
            var response = await GetRequest<LayerContract>(subUrl);

            return response;
        }

        public async Task<LayerContract[]> GetNoGoLayers(string deviceLogin, string queryString = "")
        {
            string subUrl = UrlCombine(Address.LayersNoGo, deviceLogin, queryString);
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }

        public async Task<LayerContract[]> GetLocalizationLayers(string deviceLogin, string queryString = "")
        {
            string subUrl = UrlCombine(Address.Layerslocalization, deviceLogin, queryString);
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }
    }
}
