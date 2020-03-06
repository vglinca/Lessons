using NUnit.Framework;

namespace Lesson20.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase]
        public void AddTest()
        {
            var calc = new Calculator();
            var res = calc.Add(4, 5);
            Assert.AreEqual(9, res);
        }
    }
}