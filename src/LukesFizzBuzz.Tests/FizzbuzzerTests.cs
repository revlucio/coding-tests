using NUnit.Framework;
using Shouldly;

namespace LukesFizzBuzz.Tests
{
    [TestFixture]
    public class FizzbuzzerTests
    {
        [TestCase(1, 2, "1 2")]
        [TestCase(1, 4, "1 2 lucky 4")]
        [TestCase(1, 7, "1 2 lucky 4 buzz fizz 7")]
        [TestCase(10, 16, "buzz 11 fizz lucky 14 fizzbuzz 16")]
        [TestCase(1, 15, "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz")]
        public void GivenRangeOfNumbers_ThenOutputsWithSpaces(int from, int to, string expected)
        {
            var fizzbuzzer = new Fizzbuzzer();

            var result = fizzbuzzer.Run(from, to);

            result[0].ShouldBe(expected);
        }

        [TestCase(1, 2, "fizz: 0 buzz: 0 fizzbuzz: 0 lucky: 0 integer: 2")]
        [TestCase(1, 5, "fizz: 0 buzz: 1 fizzbuzz: 0 lucky: 1 integer: 3")]
        [TestCase(1, 20, "fizz: 4 buzz: 3 fizzbuzz: 1 lucky: 2 integer: 10")]
        public void GivenRangeOfNumbers_ThenOutputsReport(int from, int to, string expected)
        {
            var fizzbuzzer = new Fizzbuzzer();

            var result = fizzbuzzer.Run(from, to);

            result[1].ShouldBe(expected);
        }
    }
}
