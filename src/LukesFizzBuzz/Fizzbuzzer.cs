using System.Linq;

namespace LukesFizzBuzz
{
    public class Fizzbuzzer
    {
        public object Run(int from, int to)
        {
            var count = to - from + 1;

            return Enumerable
                .Range(from, count)
                .Select(ConvertToFizzBuzz)
                .Aggregate((x, y) => x + " " + y);
        }

        private static string ConvertToFizzBuzz(int x)
        {
            if (x.IsDivisibleBy(3) && x.IsDivisibleBy(5))
            {
                return "fizzbuzz";
            }

            if (x.IsDivisibleBy(3))
            {
                return "fizz";
            }

            if (x.IsDivisibleBy(5))
            {
                return "buzz";
            }

            return x.ToString();
        }
    }
}