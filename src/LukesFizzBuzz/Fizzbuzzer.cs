using System;
using System.Collections.Generic;
using System.Linq;

namespace LukesFizzBuzz
{
    public class Fizzbuzzer
    {
        public List<string> Run(int from, int to)
        {
            var fizzbuzz = FizzBuzz(from, to);

            return new List<string>
            {
                fizzbuzz.ConvertToStringWithSpaces(),
                Report(fizzbuzz)
            };
        }

        private static List<string> FizzBuzz(int from, int to)
        {
            return GetRange(from, to).Select(ConvertToFizzBuzz).ToList();
        }

        private static string ConvertToFizzBuzz(int x)
        {
            if (x.ContainsDigit(3))
            {
                return "lucky";
            }

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

        private static string Report(IReadOnlyCollection<string> list)
        {
            var fizzCount = list.Count(x => x == "fizz");
            var buzzCount = list.Count(x => x == "buzz");
            var fizzbuzzCount = list.Count(x => x == "fizzbuzz");
            var luckyCount = list.Count(x => x == "lucky");
            var integerCount = list.Count -fizzCount - buzzCount - fizzbuzzCount - luckyCount;

            return String.Format("fizz: {0} buzz: {1} fizzbuzz: {2} lucky: {3} integer: {4}", 
                fizzCount, buzzCount, fizzbuzzCount, luckyCount, integerCount);
        }

        private static IEnumerable<int> GetRange(int from, int to)
        {
            var count = to - from + 1;
            return Enumerable.Range(from, count);
        }
    }
}