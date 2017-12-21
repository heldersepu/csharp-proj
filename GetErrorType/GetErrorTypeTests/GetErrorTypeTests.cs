using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetErrorType.Tests
{
    [TestClass()]
    public class GetErrorTypeTests
    {
        const int max = 1000000;

        [TestMethod()]
        public void MatchTest()
        {
            Assert.AreEqual(GetErrorType.WithIf(ErrorType.High), GetErrorType.WithSwitch(ErrorType.High));
            Assert.AreEqual(GetErrorType.WithIf(ErrorType.High), GetErrorType.WithToString(ErrorType.High));
            Assert.AreEqual(GetErrorType.WithIf(ErrorType.Low), GetErrorType.WithSwitch(ErrorType.Low));
            Assert.AreEqual(GetErrorType.WithIf(ErrorType.Low), GetErrorType.WithToString(ErrorType.Low));
        }

        [TestMethod()]
        public void WithIfTest()
        {
            for (int i = 0; i < max; i++)
            {
                Assert.IsNotNull(GetErrorType.WithIf(ErrorType.High));
                Assert.IsNotNull(GetErrorType.WithIf(ErrorType.Critical));
                Assert.IsNotNull(GetErrorType.WithIf(ErrorType.Medium));
                Assert.IsNotNull(GetErrorType.WithIf(ErrorType.Low));
            }

        }

        [TestMethod()]
        public void WithSwitchTest()
        {
            for (int i = 0; i < max; i++)
            {
                Assert.IsNotNull(GetErrorType.WithSwitch(ErrorType.High));
                Assert.IsNotNull(GetErrorType.WithSwitch(ErrorType.Critical));
                Assert.IsNotNull(GetErrorType.WithSwitch(ErrorType.Medium));
                Assert.IsNotNull(GetErrorType.WithSwitch(ErrorType.Low));
            }
        }

        [TestMethod()]
        public void WithToStringTest()
        {
            for (int i = 0; i < max; i++)
            {
                Assert.IsNotNull(GetErrorType.WithToString(ErrorType.High));
                Assert.IsNotNull(GetErrorType.WithToString(ErrorType.Critical));
                Assert.IsNotNull(GetErrorType.WithToString(ErrorType.Medium));
                Assert.IsNotNull(GetErrorType.WithToString(ErrorType.Low));
            }
        }
    }
}