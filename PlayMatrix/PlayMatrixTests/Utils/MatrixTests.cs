using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayMatrix.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void Test1_Add_10K()
        {
            int len = 10000;
            var x = new Matrix(len +10);
            x.Add(len);
            Assert.AreEqual(len, x.Count);
        }

        [TestMethod()]
        public void Test2_Add_100K()
        {
            int len = 100000;
            var x = new Matrix(len +10);
            x.Add(len);
            Assert.AreEqual(len, x.Count);
        }

        [TestMethod()]
        public void Test3_Add_1M()
        {
            int len = 1000000;
            var x = new Matrix(len +10);
            x.Add(len);
            Assert.AreEqual(len, x.Count);
        }

        [TestMethod()]
        public void Test4_Add_10M()
        {
            int len = 10000000;
            var x = new Matrix(len +10);
            x.Add(len);
            Assert.AreEqual(len, x.Count);
        }

        [TestMethod()]
        public void Test5_Add_100M()
        {
            int len = 100000000;
            var x = new Matrix(len +10);
            x.Add(len);
            Assert.AreEqual(len, x.Count);
        }
    }
}