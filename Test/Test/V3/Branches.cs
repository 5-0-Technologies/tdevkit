using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;

namespace Test
{
    //(2/2)
    public partial class TestClass
    {
        //[TestMethod]
        //public async Task Branches1()
        //{
        //    BranchContract[] branch = await devkitConnector.GetBranches();
        //    Assert.IsNotNull(branch[0]);
        //}

        //[TestMethod]
        //public async Task Branches2()
        //{
        //    BranchContract branch1 = await devkitConnector.GetBranch(1);
        //    BranchContract branch2 = null;
        //    try
        //    {
        //        branch2 = await devkitConnector.GetBranch(3);
        //    }
        //    catch (NotFoundException) { }
        //    Assert.IsNotNull(branch1);
        //    Assert.IsNull(branch2);
        //}
    }
}
