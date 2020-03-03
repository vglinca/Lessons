using NUnit.Framework;
using Lesson20;
using Moq;
using System;

namespace CalculatorNUnit
{
    [TestFixture]
    public class Tests
    {
        private Mock<Calculator> _calculatorMock;

        [SetUp]
        public void Setup()
        {
            _calculatorMock = new Mock<Calculator>();
        }

        [Test]
        public void AddTestWithTwoFixedParameters()
        {
            var res = _calculatorMock.Object.Add(4, 5);
            Assert.AreEqual(9, res);
        }

        [TestCase(12, new int[] { 3, 4, 5 })]
        [TestCase(0, new int[] { -1, -2, 3 })]
        [TestCase(22, new int[] { 2, 6, 1, -4, 12, 3, 2 })]
        public void AddTestWithMoreThanTwoParameters(int exp, int[] arr)
        {
            var res = _calculatorMock.Object.Add(arr);
            Assert.AreEqual(exp, res);
        }

        [TestCase(1, new int[] { 5, 7, -3 })]
        [TestCase(10, new int[] { -5, -7, -8 })]
        [TestCase(-5, new int[] { 5, 7, 3 })]
        public void SubstractTest(int exp, int[] arr)
        {
            var res = _calculatorMock.Object.Substract(arr);
            Assert.AreEqual(exp, res);
        }

        [TestCase(12, new int[] { 3, 4 })]
        [TestCase(0, new int[] { -1, 0, 3 })]
        [TestCase(-6, new int[] { -1, 2, 3 })]
        [TestCase(48, new int[] { -2, 3, -1, -4, -2 })]
        public void MultiplyTest(int exp, int[] arr)
        {
            var res = _calculatorMock.Object.Multiply(arr);
            Assert.AreEqual(exp, res);
        }

        [Test]
        public void DivideTest()
        {
            var res = _calculatorMock.Object.Divide(9, 3);
            Assert.AreEqual(3, res);
        }

        [Test]
        public void DivideByZeroShouldThrowACalculationException()
        {
            Assert.That(() => _calculatorMock.Object.Divide(4, 0), Throws.TypeOf<CalculationException>());
        }
    }
}