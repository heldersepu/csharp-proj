using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetErrorType.Tests
{
    [TestClass()]
    public class GetErrorTypeTests
    {
        const int max = 200000;

        [TestMethod()]
        public void MatchTest()
        {
            foreach (ErrorType e in Enum.GetValues(typeof(ErrorType)))
            {
                Assert.AreEqual(GetErrorType.WithIf(e), GetErrorType.WithSwitch(e));
                Assert.AreEqual(GetErrorType.WithIf(e), GetErrorType.WithToString(e));
                Assert.AreEqual(GetErrorType.WithIf(e), GetErrorType.WithArray(e));
            }
        }

        [TestMethod()]
        public void WithIfTest()
        {
            foreach (ErrorType e in Enum.GetValues(typeof(ErrorType)))
                for (int i = 0; i < max; i++)
                    Assert.IsNotNull(GetErrorType.WithIf(e));

        }

        [TestMethod()]
        public void WithSwitchTest()
        {
            foreach (ErrorType e in Enum.GetValues(typeof(ErrorType)))
                for (int i = 0; i < max; i++)
                    Assert.IsNotNull(GetErrorType.WithSwitch(e));
        }

        [TestMethod()]
        public void WithArray()
        {
            foreach (ErrorType e in Enum.GetValues(typeof(ErrorType)))
                for (int i = 0; i < max; i++)
                    Assert.IsNotNull(GetErrorType.WithArray(e));
        }

        [TestMethod()]
        public void WithToStringTest()
        {
            foreach (ErrorType e in Enum.GetValues(typeof(ErrorType)))
                for (int i = 0; i < max; i++)
                    Assert.IsNotNull(GetErrorType.WithToString(e));
        }

        [TestMethod()]
        public void WithDescriptionTest()
        {
            foreach (ErrorType e in Enum.GetValues(typeof(ErrorType)))
                for (int i = 0; i < max; i++)
                    Assert.IsNotNull(GetErrorType.WithDescription(e));
        }
    }
}