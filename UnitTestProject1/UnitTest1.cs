using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using stringCalculator;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void add_emptyString_return_zero()
        {
            int result = Calculator.add("");
            Assert.AreEqual(0, result);
        }
    }
}
