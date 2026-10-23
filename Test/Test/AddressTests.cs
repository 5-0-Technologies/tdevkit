using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Models;

namespace Test
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void UrlCombine_NullOrEmpty_ReturnsEmpty()
        {
            Assert.AreEqual(string.Empty, Address.UrlCombine(null));
            Assert.AreEqual(string.Empty, Address.UrlCombine());
        }

        [TestMethod]
        public void UrlCombine_TrimsSlashesAndDropsBlankSegments()
        {
            Assert.AreEqual("a/b/c", Address.UrlCombine("/a/", "\\b\\", "c"));
            Assert.AreEqual("a/c", Address.UrlCombine("a", "", "  ", "c"));
            Assert.AreEqual("alerts/checks/1", Address.UrlCombine("alerts/checks/", "1", ""));
        }
    }
}
