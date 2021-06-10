using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using SDK.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //(2/2)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Layers1()
        {
            await A_Authenticate();
            LayerContract[] layer = await devkitConnector.GetLayers();
            Assert.IsNotNull(layer[0]);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Layers2()
        {
            await A_Authenticate();
            LayerContract layer1 = await devkitConnector.GetLayer(1);
            LayerContract layer2 = null;
            try
            {
                layer2 = await devkitConnector.GetLayer(14);
            }
            catch (NotFoundException) { }
            Assert.IsNotNull(layer1);
            Assert.IsNull(layer2);
            await A_DeleteToken();
        }
    }
}
