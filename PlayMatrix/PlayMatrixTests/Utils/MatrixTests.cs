using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlayMatrix.Tests
{
    [TestClass()]
    public class Matrix_Add_Tests
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

    [TestClass()]
    public class Matrix_Find_Tests
    {
        const int len = 10000000;
        static Matrix data = new Matrix(len + 10);

        public Matrix_Find_Tests()
        {
            data.Add(len);
        }

        [TestMethod()]
        public void Test1_FindValue_10M()
        {
            int value =  data.LastValue;
            int find = data.Find(value);
            Assert.AreEqual(value, find);
        }

        [TestMethod()]
        public void Test2_FindValues_10M()
        {
            for (int i = 0; i < 10; i++)
                data.Find(i + 5000);

            int value = data.LastValue;
            int find = data.Find(value);
            Assert.AreEqual(value, find);
        }

        [TestMethod()]
        public void Test3_FindKey_10M()
        {
            int value = data.LastValue;
            int find = data[data.Count - 1];
            Assert.AreEqual(value, find);
        }
    }
}