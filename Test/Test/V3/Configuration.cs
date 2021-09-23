using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using System.Threading.Tasks;

namespace Test
{
    //(3/3)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Configuration1()
        {
            ConfigurationContract config = await devkitConnector.GetBranchConfiguration("3D_APP");
            Assert.IsNotNull(config);
        }

        [TestMethod]
        public async Task Configuration2()
        {
            ConfigurationContract config = await devkitConnector.GetAccountConfiguration("3D_APP");
            Assert.IsNotNull(config);
        }

        [TestMethod]
        public async Task Configuration3()
        {
            long config = await devkitConnector.GetConfigurationLastChange("3D_APP");
            Assert.AreNotEqual(config, -1);
        }
    }
}
