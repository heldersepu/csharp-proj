using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Decoder.Tests
{
    [TestClass()]
    public class DecoderTests
    {
        Dictionary<string, string> keys;
        public DecoderTests()
        {
            keys = new Dictionary<string, string>();
            for (int i = 0; i < 26; i++)
                keys.Add(i.ToString(), ((char)(i+65)).ToString());
        }

        [TestMethod()]
        public void CountDecoTest()
        {
            Assert.AreEqual(2, Decoder.CountDeco("12", keys));
        }

        [TestMethod()]
        public void PosibilitiesTest()
        {
            Assert.Fail();
        }
    }
}