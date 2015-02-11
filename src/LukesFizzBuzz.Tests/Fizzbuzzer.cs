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

        private static string ConvertToFizzBuzz(int x)
        {
            if (x % 3 == 0 && x % 5 == 0)
            {
                return "fizzbuzz";
            }

            if (x % 3 == 0)
            {
                return "fizz";
            }

            if (x % 5 == 0)
            {
                return "buzz";
            }

            return x.ToString();
        }
    }
}