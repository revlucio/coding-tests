using NUnit.Framework;
using Shouldly;

namespace LukesFizzBuzz.Tests
{
    [TestFixture]
    public class FizzbuzzerTests
    {
        [TestCase(1, 2, "1 2 fizz: 0 buzz: 0 fizzbuzz: 0 lucky: 0 integer: 2")]
        [TestCase(1, 5, "1 2 lucky 4 buzz fizz: 0 buzz: 1 fizzbuzz: 0 lucky: 1 integer: 3")]
        [TestCase(1, 20, "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz fizz: 4 buzz: 3 fizzbuzz: 1 lucky: 2 integer: 10")]
        public void GivenRangeOfNumbers_ThenOutputsWithSpaces(int from, int to, string expected)
        {
            var fizzbuzzer = new Fizzbuzzer();

            var result = fizzbuzzer.Run(from, to);

            result.ShouldBe(expected);
        }
    }
}
