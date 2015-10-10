using System.Text.RegularExpressions;

namespace WordSearch
{
    public interface IRegexBuilder
    {
        Regex GetRegex(string searchWord);
    }
}