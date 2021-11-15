using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Test
{
    //(0/15)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Aos1()
        {
            //await A_Authenticate();
            //OrderInfoContract[] aos = await devkitConnector.GetOrders();
            //Assert.IsNotNull(aos[0]);
            //await A_DeleteToken();
            await Task.CompletedTask;
        }

    }
}
