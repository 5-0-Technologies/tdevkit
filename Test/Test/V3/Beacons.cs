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
        public async Task Beacons1()
        {
            await A_Authenticate();
            BeaconContract[] beacon = await devkitConnector.GetBeacons();
            Assert.IsNotNull(beacon[0]);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Beacons2()
        {
            await A_Authenticate();
            BeaconContract beacon1 = await devkitConnector.GetBeacon(34);
            BeaconContract beacon2 = null;
            try
            {
                beacon2 = await devkitConnector.GetBeacon(1);
            }
            catch (NotFoundException exception) { }
            Assert.IsNotNull(beacon1);
            Assert.IsNull(beacon2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Beacons3()
        {
            await A_Authenticate();
            BeaconContract beacon = await devkitConnector.AddBeacon(TestData.GetBeacon());
            BeaconContract beacon2 = null;
            try
            {
                beacon2 = await devkitConnector.AddBeacon(TestData.GetBeacon());
            }
            catch (BadRequestException exception)
            {
                Assert.IsNull(null);
            }
            Assert.IsNotNull(beacon);
            Assert.IsNull(beacon2);
            await devkitConnector.DeleteBeacon(beacon.Id);

            try
            {
                beacon2 = await devkitConnector.GetBeacon(beacon.Id);
            }
            catch (NotFoundException exception) { }
            Assert.IsNull(beacon2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Beacons4()
        {
            await A_Authenticate();

            BeaconContract beaconData = TestData.GetBeacon();

            BeaconContract beacon = await devkitConnector.AddBeacon(beaconData);
            beacon.X = 10;
            beacon.Position = false;
            beacon.Geofence = false;
            try
            {
                var message = await devkitConnector.UpdateBeacon(beacon);
                var temp = 0;
            }
            catch (BadRequestException exception)
            {
                Assert.IsNotNull(null);
            }
            Assert.IsNotNull(beacon);
            await devkitConnector.DeleteBeacon(beacon.Id);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Beacons5()
        {
            //Delete je otestovany v add a update
        }
    }
}
