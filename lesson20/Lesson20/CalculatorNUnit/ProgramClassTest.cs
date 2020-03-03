using Lesson20;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorNUnit
{
    [TestFixture]
    public class ProgramClassTest
    {
        [TestCase(6)]
        [TestCase(-1)]
        public void StartCalculatorTest(int operation)
        {
            var calc = new Calculator();
            Assert.That(() => Program.StartCalculator(calc, operation), Throws.TypeOf<ArgumentOutOfRangeException>()
                .With
                .Matches<ArgumentOutOfRangeException>(ex => ex.ParamName == "operation")
                );
        }
    }
}
