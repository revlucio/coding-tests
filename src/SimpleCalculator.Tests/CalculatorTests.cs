using NUnit.Framework;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private ICalculator calculator;

        [SetUp]
        public void BeforeEachTest()
        {
            calculator = new Calculator();
        }

        [TestCase("1", "2", "+", 3)]
        [TestCase("3", "1", "-", 2)]
        [TestCase("1", "3", "-", -2)]
        [TestCase("-1", "3", "+", 2)]
        [TestCase("-1", "-3", "-", 2)]
        public void Parse_ShouldRunOperation(string num1, string num2, string operation, int expectedResult)
        {
            var result = calculator.Parse(num1, num2, operation);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
