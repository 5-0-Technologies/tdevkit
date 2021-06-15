using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //(4/5)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Utils1()
        {
            await A_Authenticate();
            FileInfoContract[] utils = await devkitConnector.GetDemoFilesInfo();
            Assert.IsNotNull(utils);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Utils2()
        {
            await A_Authenticate();
            byte[] utils = await devkitConnector.GetFile("00000000-0000-0000-0000-000000000001-android-manifest");
            Assert.IsNotNull(utils);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Utils3()
        {
            await A_Authenticate();
            byte[] utils = await devkitConnector.GetDemoFile("showcaseoffice-thumbnail");
            Assert.IsNotNull(utils);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Utils4()
        {
            await A_Authenticate();
            string utils = await devkitConnector.GetUnityLastVersion("windows");
            Assert.IsNotNull(utils);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Utils5()
        {
            //await A_Authenticate();
            //FileInfoContract utils = await devkitConnector.GetUnityBundleInfo();
            //Assert.IsNotNull(utils);
            //await A_DeleteToken();
        }
    }
}
