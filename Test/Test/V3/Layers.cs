using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
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
            LayerContract[] layer = await devkitConnector.GetLayers();
            Assert.IsNotNull(layer[0]);
        }

        [TestMethod]
        public async Task Layers2()
        {
            LayerContract layer1 = await devkitConnector.GetLayer(1);
            LayerContract layer2 = null;
            try
            {
                layer2 = await devkitConnector.GetLayer(15);
            }
            catch (NotFoundException exception) { }
            Assert.IsNotNull(layer1);
            Assert.IsNull(layer2);
        }

        [TestMethod]
        public async Task Layers3()
        {
            //DeviceContract device = await devkitConnector.GetDevice(8391);
            //Assert.IsNotNull(device);

            //LayerNoGoContract[] layer = await devkitConnector.GetNoGoLayers(device.Login);
            //Assert.IsNotNull(layer[0]);
        }
    }
}
