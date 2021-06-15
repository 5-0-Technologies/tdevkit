using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tDevkit;

namespace Test
{
    //(8/9)
    public partial class TestClass
    {
        //[TestMethod]
        public async Task Devices0()
        {
            DevkitConnectorV3 temp = Helper.GetConnector2();
            await devkitConnector.AddDevice(
                new DeviceContract()
                {
                    Title = "testt",
                    Login = "testt",
                    DeviceTypeId = 4
                }
            );
        }

        [TestMethod]
        public async Task Devices1()
        {
            await A_Authenticate();
            DeviceContract[] device = await devkitConnector.GetDevices();
            Assert.IsNotNull(device[0]);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Devices2()
        {
            await A_Authenticate();
            DeviceContract device1 = await devkitConnector.GetDevice(3);
            DeviceContract device2 = null;
            try
            {
                device2 = await devkitConnector.GetDevice(1);
            }
            catch (NotFoundException) { }
            Assert.IsNotNull(device1);
            Assert.IsNull(device2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Devices3()
        {
            await A_Authenticate();
            DeviceContract device1 = await devkitConnector.GetDevice("RTU1");
            DeviceContract device2 = null;
            try
            {
                device2 = await devkitConnector.GetDevice("sdk-device2");
            }
            catch (NotFoundException) { }
            Assert.IsNotNull(device1);
            Assert.IsNull(device2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Devices4()
        {
            await A_Authenticate();
            DynamicDeviceContract[] device = await devkitConnector.GetDynamicDevices();
            Assert.IsNotNull(device[0]);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Devices5()
        {
            await A_Authenticate();
            DynamicDeviceContract[] device = await devkitConnector.GetDynamicDevicesShort();
            Assert.IsNotNull(device[0]);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Devices6()
        {
            await A_Authenticate();
            DeviceContract device = await devkitConnector.AddDevice(TestData.GetDevice());
            DeviceContract device2 = null;
            try
            {
                device2 = await devkitConnector.AddDevice(TestData.GetDevice());
            }
            catch (BadRequestException)
            {
                Assert.IsNull(null);
            }
            Assert.IsNotNull(device);
            Assert.IsNull(device2);
            await devkitConnector.DeleteDevice(device.Id);

            try
            {
                device2 = await devkitConnector.GetDevice(device.Id);
            }
            catch { }
            Assert.IsNull(device2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Devices7()
        {
            await A_Authenticate();

            DeviceContract deviceData = TestData.GetDevice();

            DeviceContract device = await devkitConnector.AddDevice(deviceData);
            device.X = 20;
            device.Position = true;
            device.Note = "aaa";
            try
            {
                var message = await devkitConnector.UpdateDevice(device);
                var temp = 0;
            }
            catch (BadRequestException b)
            {
                Assert.IsNotNull(null);
            }
            Assert.IsNotNull(device);
            await devkitConnector.DeleteDevice(device.Id);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Devices8()
        {
            //Delete je otestovany v add a update
        }

        [TestMethod]
        public async Task Devices9()
        {
            //Register
        }
    }
}
