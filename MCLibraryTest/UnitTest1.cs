using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibraryCalk;

namespace MCLibraryTest
{
	[TestClass]
	public class UnitTest1
	{
		private CalcLibrary _calculator;

		[TestInitialize]
		public void Setup()
		{
			_calculator = new CalcLibrary();
		}

		[TestMethod]
		public void Test_Addition()
		{
			string expression = "5+3";
			double expected = 8;
			double actual = _calculator.Calculate(expression);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Subtraction()
		{
			string expression = "10-4";
			double expected = 6;
			double actual = _calculator.Calculate(expression);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Multiplication()
		{
			string expression = "6*7";
			double expected = 42;
			double actual = _calculator.Calculate(expression);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Division()
		{
			string expression = "15/3";
			double expected = 5;
			double actual = _calculator.Calculate(expression);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Test_Power()
		{
			string expression = "2^3";
			double expected = 8;
			double actual = _calculator.Calculate(expression);
			Assert.AreEqual(expected, actual);
		}
	}
}
