using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskProject;

namespace TestProject
{
    [TestClass]
    public class Task2Test
    {
        [TestMethod]
        public void String1Test()
        {
            double res = Task2.CalculateSum("gf5k 35yt hf 2 fd12k");
            Assert.AreEqual(54, res);
        }

        [TestMethod]
        public void NumbersAtStartAndEndTest()
        {
            double res = Task2.CalculateSum("35yt hf 2 fd-12.55");
            Assert.AreEqual(24.45, res);
        }

        [TestMethod]
        public void NegativeNumberTest()
        {
            double res = Task2.CalculateSum("-35");
            Assert.AreEqual(-35, res);
        }

        [TestMethod]
        public void DoubleNumberTest()
        {
            double res = Task2.CalculateSum("35.456");
            Assert.AreEqual(35.456, res);
        }

        [TestMethod]
        public void DoubleIntTest()
        {
            double res = Task2.CalculateSum("35.");
            Assert.AreEqual(35.0, res);
        }

        [TestMethod]
        public void NoIntPartTest()
        {
            double res = Task2.CalculateSum("qwe-.5rty");
            Assert.AreEqual(5, res);
        }
    }
}
