using System.Collections.Generic;
using System.Linq;

namespace WordSearch
{
    public class WordSearcher
    {
        private readonly IWordLoader _wordLoader;
        private readonly IRegexBuilder _regexBuilder;

        public WordSearcher(IWordLoader wordLoader, IRegexBuilder regexBuilder)
        {
            _wordLoader = wordLoader;
            _regexBuilder = regexBuilder;
        }

        public List<string> FindMatches(int length, string searchWord)
        {
            var words = _wordLoader.GetWordsFromUrl();
            var filteredWords = words.Where(w => w.Length == length);
            
            var regex = _regexBuilder.GetRegex(searchWord);
            filteredWords = filteredWords.Where(w => regex.IsMatch(w));

            return filteredWords.OrderBy(w => w).ToList();
        }
    }
}