using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lesson20;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Lesson20.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AddTest()
        {
            Calculator calc = new Calculator();
            var res = calc.Add(new int[] { 2, 3, 4 });
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Equals(9, res);
        }

        [Test]
        public void DivideTest()
        {
            Calculator calc = new Calculator();
            var res = calc.Divide(6, 3);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Equals(2, res);
        }
    }
}