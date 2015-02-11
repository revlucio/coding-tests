using System.Collections.Generic;
using System.Linq;

namespace LukesFizzBuzz
{
    public static class EnumerableExtensions
    {
        public static string ConvertToStringWithSpaces(this IEnumerable<string> list)
        {
            return list.Aggregate((x, y) => x + " " + y);
        }
    }
}