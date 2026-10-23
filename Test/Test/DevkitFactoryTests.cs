using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK;

namespace Test
{
    [TestClass]
    public class DevkitFactoryTests
    {
        private static ConnectionOptions Options(string version)
        {
            return new ConnectionOptionsBuilder()
                .Url("http://localhost:8000/api")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("key")
                .Version(version)
                .Build();
        }

        [TestMethod]
        public void CreateDevkitConnector_Version3_ReturnsV3()
        {
            var connector = DevkitFactory.CreateDevkitConnector(Options(ConnectionOptions.VERSION_3));
            Assert.IsInstanceOfType(connector, typeof(DevkitConnectorV3));
        }

        [TestMethod]
        public void CreateDevkitConnector_Version5_ReturnsV5()
        {
            var connector = DevkitFactory.CreateDevkitConnector(Options(ConnectionOptions.VERSION_5));
            Assert.IsInstanceOfType(connector, typeof(DevkitConnectorV5));
        }

        [TestMethod]
        public void CreateDevkitConnector_UnknownVersion_ReturnsNull()
        {
            Assert.IsNull(DevkitFactory.CreateDevkitConnector(Options("v9")));
        }
    }
}
