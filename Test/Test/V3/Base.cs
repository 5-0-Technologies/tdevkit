using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tDevkit;

namespace Test
{
    [TestClass]
    public partial class TestClass
    {
        private DevkitConnectorV3 devkitConnector = Helper.GetConnector();
    }
}
