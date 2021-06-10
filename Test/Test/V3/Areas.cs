using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using SDK.Exceptions;
using SDK.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using tDevkit;

namespace Test
{
    //(2/2)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Areas1()
        {
            await A_Authenticate();
            AreaContract[] area = await devkitConnector.GetAreas();
            Assert.IsNotNull(area[0]);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Areas2()
        {
            await A_Authenticate();
            AreaContract area1 = await devkitConnector.GetArea(1);
            AreaContract area2 = null;
            try
            {
                area2 = await devkitConnector.GetArea(3);
            }
            catch (NotFoundException) {}
            Assert.IsNotNull(area1);
            Assert.IsNull(area2);
            await A_DeleteToken();
        }
    }
}
