using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //(1/1)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Users1()
        {
            await devkitConnector.Authenticate("sdk-user", "K0H4k0gal2gyqem", false);
            UserContract user = await devkitConnector.GetUserInfo();
            Assert.IsNotNull(user);
        }
    }
}
