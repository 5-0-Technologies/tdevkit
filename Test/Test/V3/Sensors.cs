using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;

namespace Test
{
    //(9/10)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Sensors1()
        {
            SensorContract[] sensor = await devkitConnector.GetSensors();
            Assert.IsNotNull(sensor[0]);
        }

        [TestMethod]
        public async Task Sensors2()
        {
            SensorContract sensor1 = await devkitConnector.GetSensor(5271);
            SensorContract sensor2 = null;
            try
            {
                sensor2 = await devkitConnector.GetSensor(1);
            }
            catch (NotFoundException) { }
            Assert.IsNotNull(sensor1);
            Assert.IsNull(sensor2);
        }

        [TestMethod]
        public async Task Sensors3()
        {
            SensorContract sensor1 = await devkitConnector.GetSensor("enviro-sdk");
            SensorContract sensor2 = null;
            try
            {
                sensor2 = await devkitConnector.GetSensor("notexistentlogin");
            }
            catch (NotFoundException) { }
            Assert.IsNotNull(sensor1);
            Assert.IsNull(sensor2);
        }

        [TestMethod]
        public async Task Sensors4()
        {
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
            catch (NotFoundException) { }
            Assert.IsNull(sensor2);
        }

        [TestMethod]
        public async Task Sensors5()
        {
            SensorContract sensorData = TestData.GetSensor();

            SensorContract sensor = await devkitConnector.AddSensor(sensorData);
            sensor.X = 10;
            sensor.SensorData = null;
            try
            {
                var message = await devkitConnector.UpdateSensor(sensor);
            }
            catch (BadRequestException)
            {
                Assert.IsNotNull(null);
            }
            Assert.IsNotNull(sensor);
            await devkitConnector.DeleteSensor(sensor.Id);
        }

        [TestMethod]
        public async Task Sensors6()
        {
            //Delete je otestovany v add a update
        }

        [TestMethod]
        public async Task Sensors7()
        {
            //await A_Authenticate();
            PostResponseContract[] sensor = await devkitConnector.AddSensorData(TestData.GetSensorDataBatch());
            Assert.IsTrue(sensor[0].Success);
            //await A_DeleteToken();
        }

        [TestMethod]
        public async Task Sensors8()
        {
            await devkitConnector.Authenticate("enviro-sdk", "Hh2jCnvU1sd653K", false);
            AddSensorDataResponseContract sensor = (AddSensorDataResponseContract)await devkitConnector.AddSensorData(TestData.GetSensorData());
            Assert.IsNotNull(sensor.SensorData);
        }

        [TestMethod]
        public async Task Sensors9()
        {
            SensorAppInfoContract sensorAppInfoContract = await devkitConnector.GetSensorAppInfo();
            Assert.IsNotNull(sensorAppInfoContract);
        }

        [TestMethod]
        public async Task Sensors10()
        {

        }
    }
}
