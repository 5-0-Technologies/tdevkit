using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Communication;
using System.Threading.Tasks;

namespace Test
{
    //(2/2)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Localization1()
        {
            PostResponseContract[] local = await devkitConnector.AddLocalizationData(TestData.GetLocalizationDataBatch());
            Assert.IsTrue(local[0].Success);
        }

        [TestMethod]
        public async Task Localization2()
        {
            await devkitConnector.Authenticate("rtu-sdk", "RONsM9KzoiRW2vO", false);
            PostResponseContract local = await devkitConnector.AddLocalizationData(TestData.GetLocalizationData());
            Assert.IsTrue(local.Success);
        }
    }
}
