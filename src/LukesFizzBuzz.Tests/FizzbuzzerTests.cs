using NUnit.Framework;
using Shouldly;

namespace LukesFizzBuzz.Tests
{
    [TestFixture]
    public class FizzbuzzerTests
    {
        [TestCase(1, 2, "1 2")]
        [TestCase(1, 4, "1 2 fizz 4")]
        [TestCase(1, 7, "1 2 fizz 4 buzz fizz 7")]
        [TestCase(10, 16, "buzz 11 fizz 13 14 fizzbuzz 16")]
        public void GivenRangeOfNumbers_ThenOutputsWithSpaces(int from, int to, string expected)
        {
            var fizzbuzzer = new Fizzbuzzer();

            var result = fizzbuzzer.Run(from, to);

            result.ShouldBe(expected);
        }
    }
}
