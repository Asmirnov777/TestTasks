using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskProject;

namespace TestProject
{
    [TestClass]
    public class Task1Test
    {
        [TestMethod]
        public void String1Test()
        {
            string res = Task1.DefineCommonStart("abc abcd abe abk");
            Assert.AreEqual("ab", res);
        }

        [TestMethod]
        public void String2Test()
        {
            string res = Task1.DefineCommonStart("abc dfg tyu yui");
            Assert.AreEqual("-", res);
        }

        [TestMethod]
        public void EmptyStringTest()
        {
            string res = Task1.DefineCommonStart("");
            Assert.AreEqual("-", res);
        }

        [TestMethod]
        public void EqualStringsTest()
        {
            string res = Task1.DefineCommonStart("1234 1234 1234 1234");
            Assert.AreEqual("1234", res);
        }

        [TestMethod]
        public void SingleStringTest()
        {
            string res = Task1.DefineCommonStart("singleString");
            Assert.AreEqual("singleString", res);
        }

    }
}
