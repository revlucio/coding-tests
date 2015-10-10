using System;

namespace LukesFizzBuzz
{
    public class Fizzbuzzer
    {
        private int _fizzCount;
        private int _buzzCount;
        private int _fizzbuzzCount;
        private int _luckyCount;
        private int _integerCount;

        public string Run(int from, int to)
        {
            return ConvertToStringWithSpaces(from, to) + GetReport();
        }

        private string ConvertToStringWithSpaces(int from, int to)
        {
            var output = String.Empty;

            for (var i = from; i < (to + 1); i++)
            {
                output += ConvertToFizzBuzz(i) + " ";
            }

            return output;
        }

        private string ConvertToFizzBuzz(int x)
        {
            if (x.ContainsDigit(3))
            {
                _luckyCount++;
                return "lucky";
            }

            if (x.IsDivisibleBy(15))
            {
                _fizzbuzzCount++;
                return "fizzbuzz";
            }

            if (x.IsDivisibleBy(3))
            {
                _fizzCount++;
                return "fizz";
            }

            if (x.IsDivisibleBy(5))
            {
                _buzzCount++;
                return "buzz";
            }

            _integerCount++;
            return x.ToString();
        }

        private string GetReport()
        {
            return String.Format("fizz: {0} buzz: {1} fizzbuzz: {2} lucky: {3} integer: {4}", 
                _fizzCount, _buzzCount, _fizzbuzzCount, _luckyCount, _integerCount);
        }
    }
}