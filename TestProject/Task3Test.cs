using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskProject;

namespace TestProject
{
    [TestClass]
    public class Task3Test
    {
        [TestMethod]
        public void ExpressionTest1()
        {
            string[] strArray = "+ 3 * 8 5".Split(' ');
            double res = Task3.CalculateExpression(strArray);
            Assert.AreEqual(43.0, res);
        }

        [TestMethod]
        public void ExpressionTest2()
        {
            string[] strArray = "+ - + 3 / * 8 5 2 8 * 4 -4".Split(' ');
            double res = Task3.CalculateExpression(strArray);
            Assert.AreEqual(-1.0, res);
        }

        [TestMethod]
        public void ExpressionTest3()
        {
            string[] strArray = "+ + * / * -5 4 2 3 * 8 3 -200".Split(' ');
            double res = Task3.CalculateExpression(strArray);
            Assert.AreEqual(-206.0, res);
        }

        [TestMethod]
        public void OneNumberTest()
        {
            string[] strArray = "3".Split(' ');
            double res = Task3.CalculateExpression(strArray);
            Assert.AreEqual(3.0, res);
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void NotIntegerNumberTest()
        {
            string[] strArray = "* -2.5 4".Split(' ');
            double res = Task3.CalculateExpression(strArray);
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void OneOperatorTest()
        {
            string[] strArray = "+".Split(' ');
            double res = Task3.CalculateExpression(strArray);
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void WrongOperatorTest()
        {
            string[] strArray = "% 3 4".Split(' ');
            double res = Task3.CalculateExpression(strArray);
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void NullStringTest()
        {
            double res = Task3.CalculateExpression(null);
        }


        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void NullLengthStringTest()
        {
            double res = Task3.CalculateExpression(new string[] { });
        }
    }
}
