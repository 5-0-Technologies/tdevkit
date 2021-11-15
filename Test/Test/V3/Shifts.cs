using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using SDK.Exceptions;
using System.Threading.Tasks;

namespace Test
{
    //(2/2)
    public partial class TestClass
    {
        //[TestMethod]
        //public async Task Shifts1()
        //{
        //    ShiftContract[] shift = await devkitConnector.GetShifts();
        //    Assert.IsNotNull(shift[0]);
        //}

        //TODO test is not correct use wire.net
        //[TestMethod]
        //public async Task Shifts2()
        //{
        //    ShiftContract shift1 = await devkitConnector.GetShift(1);
        //    ShiftContract shift2 = null;
        //    try
        //    {
        //        shift2 = await devkitConnector.GetShift(6);
        //    }
        //    catch (NotFoundException) { }
        //    Assert.IsNotNull(shift1);
        //    Assert.IsNull(shift2);
        //}
    }
}
