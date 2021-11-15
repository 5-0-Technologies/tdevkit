using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;

namespace Test
{
    //(5/5)
    public partial class TestClass
    {
        //[TestMethod]
        //public async Task Beacons1()
        //{
        //    BeaconContract[] beacon = await devkitConnector.GetBeacons();
        //    Assert.IsNotNull(beacon[0]);
        //}

        //[TestMethod]
        //public async Task Beacons2()
        //{
        //    BeaconContract beacon1 = await devkitConnector.GetBeacon(34);
        //    BeaconContract beacon2 = null;
        //    try
        //    {
        //        beacon2 = await devkitConnector.GetBeacon(1);
        //    }
        //    catch (NotFoundException) { }
        //    Assert.IsNotNull(beacon1);
        //    Assert.IsNull(beacon2);
        //}

        //TODO test is not correct use wire.net
        //[TestMethod]
        //public async Task Beacons3()
        //{
        //    BeaconContract beacon = await devkitConnector.AddBeacon(TestData.GetBeacon());
        //    BeaconContract beacon2 = null;
        //    try
        //    {
        //        beacon2 = await devkitConnector.AddBeacon(TestData.GetBeacon());
        //    }
        //    catch (BadRequestException)
        //    {
        //        Assert.IsNull(null);
        //    }
        //    Assert.IsNotNull(beacon);
        //    Assert.IsNull(beacon2);
        //    await devkitConnector.DeleteBeacon(beacon.Id);

        //    try
        //    {
        //        beacon2 = await devkitConnector.GetBeacon(beacon.Id);
        //    }
        //    catch (NotFoundException) { }
        //    Assert.IsNull(beacon2);
        //}

        //TODO test is not correct use wire.net
        //[TestMethod]
        //public async Task Beacons4()
        //{
        //    BeaconContract beaconData = TestData.GetBeacon();

        //    BeaconContract beacon = await devkitConnector.AddBeacon(beaconData);
        //    beacon.X = 10;
        //    beacon.Position = false;
        //    beacon.Geofence = false;
        //    try
        //    {
        //        var message = await devkitConnector.UpdateBeacon(beacon);
        //    }
        //    catch (BadRequestException)
        //    {
        //        Assert.IsNotNull(null);
        //    }
        //    Assert.IsNotNull(beacon);
        //    await devkitConnector.DeleteBeacon(beacon.Id);
        //}

        //[TestMethod]
        //public async Task Beacons5()
        //{
        //    //Delete je otestovany v add a update
        //    await Task.CompletedTask;
        //}
    }
}
