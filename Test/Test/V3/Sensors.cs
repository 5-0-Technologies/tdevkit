using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //(8/9)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Sensors1()
        {
            await A_Authenticate();
            SensorContract[] sensor = await devkitConnector.GetSensors();
            Assert.IsNotNull(sensor[0]);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sensors2()
        {
            await A_Authenticate();
            SensorContract sensor1 = await devkitConnector.GetSensor(37);
            SensorContract sensor2 = null;
            try
            {
                sensor2 = await devkitConnector.GetSensor(1);
            }
            catch (NotFoundException) { }
            Assert.IsNotNull(sensor1);
            Assert.IsNull(sensor2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sensors3()
        {
            await A_Authenticate();
            SensorContract sensor = await devkitConnector.AddSensor(TestData.GetSensor());
            SensorContract sensor2 = null;
            try
            {
                sensor2 = await devkitConnector.AddSensor(TestData.GetSensor());
            }
            catch (BadRequestException)
            {
                Assert.IsNull(null);
            }
            Assert.IsNotNull(sensor);
            Assert.IsNull(sensor2);
            await devkitConnector.DeleteSensor(sensor.Id);

            try
            {
                sensor2 = await devkitConnector.GetSensor(sensor.Id);
            }
            catch { }
            Assert.IsNull(sensor2);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sensors4()
        {
            await A_Authenticate();

            SensorContract sensorData = TestData.GetSensor();

            SensorContract sensor = await devkitConnector.AddSensor(sensorData);
            sensor.X = 10;
            sensor.SensorData = null;
            try
            {
                var message = await devkitConnector.UpdateSensor(sensor);
                var temp = 0;
            }
            catch (BadRequestException b)
            {
                Assert.IsNotNull(null);
            }
            Assert.IsNotNull(sensor);
            await devkitConnector.DeleteSensor(sensor.Id);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sensors5()
        {
            //Delete je otestovany v add a update
        }

        [TestMethod]
        public async Task Sensors6()
        {
            await A_Authenticate();
            PostResponseContract[] sensor = await devkitConnector.AddSensorData(TestData.GetSensorDataBatch());
            Assert.IsTrue(sensor[0].Success);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sensors7()
        {
            await devkitConnector.Authenticate("enviro-sdk", "Hh2jCnvU1sd653K", false);
            PostResponseContract sensor = await devkitConnector.AddSensorData(TestData.GetSensorData());
            Assert.IsTrue(sensor.Success);
        }

        [TestMethod]
        public async Task Sensors8()
        {
            await A_Authenticate();
            SensorAppInfoContract sensorAppInfoContract = await devkitConnector.GetSensorAppInfo();
            Assert.IsNotNull(sensorAppInfoContract);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sensors9()
        {

        }
    }
}
