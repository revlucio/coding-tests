using System.Linq;

namespace LukesFizzBuzz.Tests
{
    public class Fizzbuzzer
    {
        public object Run(int from, int to)
        {
            var count = to - from + 1;

            return Enumerable.Range(from, count)
                .Select(ConvertToFizzBuzz)
                .Aggregate((x, y) => x + " " + y);
        }

        private static string ConvertToFizzBuzz(int number)
        {
            if (number.IsDivisibleBy(3) && number.IsDivisibleBy(5))
            {
                return "fizzbuzz";
            }

            if (number.IsDivisibleBy(3))
            {
                return "fizz";
            }

            if (number.IsDivisibleBy(5))
            {
                return "buzz";
            }

            return number.ToString();
        }
    }
}