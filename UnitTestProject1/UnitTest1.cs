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
        [TestMethod]
        public void add_oneNumber_return_it()
        {
            int resutl = Calculator.add("1");
            Assert.AreEqual(1, resutl);
        }
        [TestMethod]
        public void add_two_number_comma_seperated_returnSum()
        {
            int result = Calculator.add("1,2");
            Assert.AreEqual(3, result);
        }
        [TestMethod]
        public void add_unkown_amount_numbers()
        {
            int result = Calculator.add("20,42,35,60");
            Assert.AreEqual(20 + 42 + 35 + 60, result);

        }
    }
}
