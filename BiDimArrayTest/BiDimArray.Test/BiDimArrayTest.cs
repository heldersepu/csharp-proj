using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BiDimArray.Test
{
    [TestClass]
    public class BiDimArrayTest
    {
        [TestMethod]
        public void TestArray()
        {
            var array = new BiDimArray();
            Assert.AreEqual("Ms.", array.Test(true, false));
            Assert.AreEqual("Mr.", array.Test(false, false));
            Assert.AreEqual("Sir", array.Test(false, true));
            Assert.AreEqual("Dame", array.Test(true, true));
        }
    }
}
