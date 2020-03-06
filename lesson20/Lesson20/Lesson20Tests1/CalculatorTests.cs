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
        public void DivideTest()
        {
            var calc = new Calculator();
            var res = calc.Divide(6, 3);
            Assert.AreEqual(2, res);
        }
    }
}