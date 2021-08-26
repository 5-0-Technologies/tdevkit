using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    //(2/2)
    public partial class TestClass
    {
        [TestMethod]
        public async Task Shifts1()
        {
            ShiftContract[] shift = await devkitConnector.GetShifts();
            Assert.IsNotNull(shift[0]);
        }

        [TestMethod]
        public async Task Shifts2()
        {
            ShiftContract shift1 = await devkitConnector.GetShift(1);
            ShiftContract shift2 = null;
            try
            {
                shift2 = await devkitConnector.GetShift(6);
            }
            catch (NotFoundException exception) { }
            Assert.IsNotNull(shift1);
            Assert.IsNull(shift2);
        }
    }
}
