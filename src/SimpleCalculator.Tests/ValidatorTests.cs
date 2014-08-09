using NUnit.Framework;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        [TestCase("2", 2, TestName = "ReturnsValidIfInteger")]
        [TestCase("-2", -2, TestName = "ReturnsValidIfNegative")]
        [TestCase("s", null, TestName = "ReturnsInvalidIfString")]
        [TestCase("1.5", null, TestName = "ReturnsInvalidIfDecimal")]
        public void IsValidNumber(string input, int? expected)
        {
            IValidator validator = new Validator();
            Assert.That(validator.ToValidNumber(input), Is.EqualTo(expected));
        }

        [TestCase("+", true, TestName = "ReturnsTrueIfAddition")]
        [TestCase("-", true, TestName = "ReturnsTrueIfSubtraction")]
        [TestCase("*", false, TestName = "ReturnsFalseIfMultiplication")]
        public void IsValidOperation(string input, bool expected)
        {
            IValidator validator = new Validator();
            Assert.That(validator.IsValidOperation(input), Is.EqualTo(expected));
        }
    }
}
