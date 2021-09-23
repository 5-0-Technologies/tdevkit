using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using System.Threading.Tasks;

namespace Test
{
    //(4/5)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Utils1()
        {
            FileInfoContract[] utils = await devkitConnector.GetDemoFilesInfo();
            Assert.IsNotNull(utils);
        }

        [TestMethod]
        public async Task Utils2()
        {
            byte[] utils = await devkitConnector.GetFile("00000000-0000-0000-0000-000000000001-android-manifest");
            Assert.IsNotNull(utils);
        }

        [TestMethod]
        public async Task Utils3()
        {
            byte[] utils = await devkitConnector.GetDemoFile("showcaseoffice-thumbnail");
            Assert.IsNotNull(utils);
        }

        [TestMethod]
        public async Task Utils4()
        {
            string utils = await devkitConnector.GetUnityLastVersion("windows");
            Assert.IsNotNull(utils);
        }

        [TestMethod]
        public async Task Utils5()
        {
            FileInfoContract utils = await devkitConnector.GetUnityBundleInfo("6CCF17C9-53EC-4825-8ECB-2DAD95655018-windows");
            Assert.IsNotNull(utils);
        }
    }
}
