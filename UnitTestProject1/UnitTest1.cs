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
            int result = Calculator.add("1");
            Assert.AreEqual(1, result);
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
        [TestMethod]
        public void add_numbers_separated_with_newline()
        {
            int result = Calculator.add("20\n30,40");
            Assert.AreEqual(90, result);

        }
        [TestMethod]
        public void add_with_different_delimiters()
        {
            int result = Calculator.add("//;\n20;30;40");
            Assert.AreEqual(90, result);
        }
        [TestMethod]
       [ExpectedException(typeof(ArgumentException),"negatives not allowed: -1")]
        public void add_throws_exception_with_negative_numbers()
        {

            Calculator.add("//,\n-1,-2,3");

        }
        [TestMethod]
        public void add_ignores_numbers_greater_than_1000()
        {
            int result=Calculator.add("//;\n20;30;40;1001");
            Assert.AreEqual(90,result);
        }
        [TestMethod]
        public void add_numbers_with_anyLength_delimiters()
        {
            int result = Calculator.add("//[**]\n20**30**40");
            Assert.AreEqual(90,result);
        }
        [TestMethod]
        public void add_numbers_with_multiple_delimiters_with_anyLength()
        {
            int result = Calculator.add("//[**][%]\n20**30%40");
            Assert.AreEqual(90,result);

        }
    }
}
