using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;
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
        public async Task Clients1()
        {
            ClientContract[] client = await devkitConnector.GetClients();
            Assert.IsNotNull(client[0]);
        }
    }
}
