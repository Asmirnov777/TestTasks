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
            goodTestTemplate("3 + 8 * 5", 43.0);
        }

        [TestMethod]
        public void ExpressionTest2()
        {
            goodTestTemplate("3 + 8 * 5 / 2 - 8 + 4 * -4", -1.0);
        }

        [TestMethod]
        public void ExpressionTest3()
        {
            goodTestTemplate("-5 * 4 / 2 * 3 + 8 * 3 + -200", -206.0);
        }

        [TestMethod]
        public void OneNumberTest()
        {
            goodTestTemplate("3", 3.0);
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void TwoOperatorsTogetherTest()
        {
            tasksExceptionTestTemplate("3 + 8 * 5 / 2 - 8 + 4 * - 4");
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void TwoOperatorsInOneStringTest()
        {
            tasksExceptionTestTemplate("3 + 8 * 5 / 2 - 8 + 4 * - 4");
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void NotIntegerNumberTest()
        {
            tasksExceptionTestTemplate("-2.5 * 4 / 2 * 3 + 8 * 3 + -200");
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void OneOperatorTest()
        {
            tasksExceptionTestTemplate("+");
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void WrongOperatorTest()
        {
            tasksExceptionTestTemplate("3 % 4");
        }

        [TestMethod]
        [ExpectedException(typeof(TasksException))]
        public void TwoNumbersTogetherTest()
        {
            tasksExceptionTestTemplate("-68 + 3 67 * 4");
        }

        private Task3 task3UsingPriorities = new Task3UsingPriorities(),
                      task3OnePass = new Task3OnePass();

        private void goodTestTemplate(string str, double expectedRes)
        {
            string[] strArray = str.Split(' ');
            double res = task3UsingPriorities.CalculateExpression(strArray);
            Assert.AreEqual(expectedRes, res);
            res = task3OnePass.CalculateExpression(strArray);
            Assert.AreEqual(expectedRes, res);
        }

        private void tasksExceptionTestTemplate(string str)
        {
            string[] strArray = str.Split(' ');
            try
            {
                task3UsingPriorities.CalculateExpression(strArray);
            }
            catch (TasksException)
            {
                task3OnePass.CalculateExpression(strArray);
            }
            Assert.Fail();
        }
    }
}
