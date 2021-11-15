using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK;

namespace Test
{
    [TestClass]
    public partial class TestClass
    {
        private readonly DevkitConnectorV3 devkitConnector = Helper.GetConnector();
    }
}
