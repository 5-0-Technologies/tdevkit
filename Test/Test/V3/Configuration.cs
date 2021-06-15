using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //(3/3)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Configuration1()
        {
            await A_Authenticate();
            ConfigurationContract config = await devkitConnector.GetBranchConfiguration("3D_APP");
            Assert.IsNotNull(config);
            await A_DeleteToken();
        }

        [TestMethod]
        public async Task Configuration2()
        {
            await devkitConnector.Authenticate("rtu-sdk", "RONsM9KzoiRW2vO", false);
            ConfigurationContract config = await devkitConnector.GetAccountConfiguration("3D_APP");
            Assert.IsNotNull(config);
        }

        [TestMethod]
        public async Task Configuration3()
        {
            await A_Authenticate();
            long config = await devkitConnector.GetConfigurationLastChange("3D_APP");
            Assert.AreEqual(config, -1);
            await A_DeleteToken();
        }
    }
}
