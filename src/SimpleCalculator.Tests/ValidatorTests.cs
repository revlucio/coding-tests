using NUnit.Framework;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        [TestCase("2", true, TestName = "ReturnsTrueIfInteger")]
        [TestCase("-2", true, TestName = "ReturnsTrueIfNegative")]
        [TestCase("s", false, TestName = "ReturnsFalseIfString")]
        [TestCase("1.5", false, TestName = "ReturnsFalseIfDecimal")]
        public void IsValidNumber(string input, bool expected)
        {
            IValidator validator = new Validator();
            Assert.That(validator.IsValidNumber(input), Is.EqualTo(expected));
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
