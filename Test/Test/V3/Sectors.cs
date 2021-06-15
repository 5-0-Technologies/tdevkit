using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //(5/5)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Sectors1()
        {
            await A_Authenticate();
            SectorContract[] sector = await devkitConnector.GetSectors();
            Assert.IsNotNull(sector[0]);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sectors2()
        {
            await A_Authenticate();
            SectorContract sector1 = await devkitConnector.GetSector(1);
            SectorContract sector2 = null;
            try
            {
                sector2 = await devkitConnector.GetSector(5);
            }
            catch (NotFoundException) { }
            Assert.IsNotNull(sector1);
            Assert.IsNull(sector2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sectors3()
        {
            await A_Authenticate();
            SectorContract sector = await devkitConnector.AddSector(TestData.GetSector());
            Assert.IsNotNull(sector);
            await devkitConnector.DeleteSector(sector.Id);

            SectorContract sector2 = null;
            try
            {
                sector2 = await devkitConnector.GetSector(sector.Id);
            }
            catch { }
            Assert.IsNull(sector2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sectors4()
        {
            await A_Authenticate();
            SectorContract sectorData = TestData.GetSector();
            SectorContract sector = await devkitConnector.AddSector(sectorData);
            sector.Title = "aaa";
            sector.BarrierWidth = 20;
            try
            {
                var message = await devkitConnector.UpdateSector(sector);
                var temp = 0;
            }
            catch (BadRequestException b)
            {
                Assert.IsNotNull(null);
            }
            Assert.IsNotNull(sector);
            await devkitConnector.DeleteSector(sector.Id);
            await A_DeleteToken();
        }


        [TestMethod]
        public async Task Sectors5()
        {
            //Delete je otestovany v add a update
        }
    }
}
