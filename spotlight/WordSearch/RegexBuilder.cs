using System.Linq;
using System.Text.RegularExpressions;

namespace WordSearch
{
    public class RegexBuilder : IRegexBuilder
    {
        public Regex GetRegex(string searchWord)
        {
            var regextString = searchWord.ToCharArray()
                .Aggregate(".*", (current, c) => current + (c + ".*"));

            return new Regex(regextString);
        }
    }
}