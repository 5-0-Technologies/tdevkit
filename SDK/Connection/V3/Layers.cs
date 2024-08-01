using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    //(2/2)
    public partial class DevkitConnectorV3
    {
        public async Task<LayerContract[]> GetLayers(string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Layers, queryString);
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }

        public async Task<LayerContract> GetLayer(int id, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Layers, Convert.ToString(id), queryString);
            var response = await GetRequest<LayerContract>(subUrl);

            return response;
        }

        public async Task<LayerContract[]> GetNoGoLayers(string deviceLogin, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.LayersNoGo, deviceLogin, queryString);
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }

        public async Task<LayerContract[]> GetLocalizationLayers(string deviceLogin, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Layerslocalization, deviceLogin, queryString);
            var response = await GetRequest<LayerContract[]>(subUrl);

            return response;
        }

        public async Task<LayerContract[]> GetLocalizationLayers(LoginContract loginContract, string queryString = "")
        {
            string subUrl = Address.UrlCombine(Address.Layerslocalization, queryString);
            var response = await PostRequest<LayerContract[]>(subUrl, loginContract);

            return response;
        }

        public async Task<LayerContract> AddLayer(LayerContract layer)
        {
            string subUrl = Address.UrlCombine(Address.Layers);
            var response = await PostRequest<LayerContract>(subUrl, layer);

            return response;
        }

        public async Task UpdateLayer(int id, object changes)
        {
            string subUrl = Address.UrlCombine(Address.Layers, id.ToString());
            await PatchRequest(subUrl, changes);
        }

        public async Task DeleteLayer(int id)
        {
            string subUrl = Address.UrlCombine(Address.Layers, Convert.ToString(id));
            await DeleteRequest(subUrl);
        }
    }
}
