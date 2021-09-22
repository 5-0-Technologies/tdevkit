using Flurl;
using SDK.Contracts.Data;
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
        public async Task<LayerContract[]> GetLayers(string queryString = "")
        {
            string subUrl = Url.Combine(Address.Layers, queryString);
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }

        public async Task<LayerContract> GetLayer(int id, string queryString = "")
        {
            string subUrl = Url.Combine(Address.Layers, Convert.ToString(id), queryString);
            var response = await GetRequest<LayerContract>(subUrl);

            return response;
        }

        public async Task<LayerContract[]> GetLocalizationLayers(string deviceLogin, string queryString = "")
        {
            string subUrl = Url.Combine(Address.LayersNoGo, deviceLogin, queryString);
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }
    }
}
