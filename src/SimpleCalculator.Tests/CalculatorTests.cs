using NUnit.Framework;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private ICalculator _calculator;

        [SetUp]
        public void BeforeEachTest()
        {
            _calculator = new Calculator(new OperationFactory());
        }

        [TestCase(1, 2, "+", 3)]
        [TestCase(3, 1, "-", 2)]
        [TestCase(1, 3, "-", -2)]
        [TestCase(-1, 3, "+", 2)]
        [TestCase(-1, -3, "-", 2)]
        public void Parse_ShouldRunOperation(int num1, int num2, string operation, int expectedResult)
        {
            var result = _calculator.Parse(num1, num2, operation);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
