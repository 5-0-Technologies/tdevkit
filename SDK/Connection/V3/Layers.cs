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
        public async Task<LayerContract[]> GetLayers()
        {
            string subUrl = Address.Layers;
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }
        public async Task<LayerContract> GetLayer(int id)
        {
            string subUrl = Address.Layers + id;
            var response = await GetRequest<LayerContract>(subUrl);

            return response;
        }
        public async Task<LayerNoGoContract[]> GetNoGoLayers(string deviceLogin)
        {
            string subUrl = Address.LayersNoGo + deviceLogin;
            var response = await GetRequest<LayerNoGoContract[]>(subUrl);

            return response;
        }
    }
}
