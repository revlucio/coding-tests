namespace LukesFizzBuzz
{
    public static class IntExtensions
    {
        public static bool IsDivisibleBy(this int dividend, int divisor)
        {
            return (dividend % divisor == 0);
        }

        public static bool ContainsDigit(this int number, int digit)
        {
            return (number.ToString().Contains(digit.ToString()));
        }
    }
}