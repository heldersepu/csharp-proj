using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Tests
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        public void SwapCaseTest()
        {
            Assert.AreEqual("Hello", "hELLO".SwapCase());
            Assert.AreEqual("HelloWorld", "hELLOwORLD".SwapCase());
            Assert.AreEqual("Hello World", "hELLO wORLD".SwapCase());

            Assert.AreEqual("AAAA", "aaaa".SwapCase());
            Assert.AreEqual("aaaa", "AAAA".SwapCase());

            Assert.AreEqual("ZZZZ", "zzzz".SwapCase());
            Assert.AreEqual("zzzz", "ZZZZ".SwapCase());

            Assert.AreEqual("123", "123".SwapCase());
            Assert.AreEqual("!@#", "!@#".SwapCase());
        }
    }
}