using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordSearch
{
    public class WordSearcher
    {
        private readonly IWordLoader _wordLoader;

        public WordSearcher(IWordLoader wordLoader)
        {
            _wordLoader = wordLoader;
        }

        public List<string> FindMatches(int length, string searchWord)
        {
            var words = _wordLoader.GetWordsFromUrl();
            var filteredWords = words.Where(w => w.Length == length);

            var regextString = searchWord.ToCharArray()
                .Aggregate(".*", (current, c) => current + (c + ".*"));

            var regex = new Regex(regextString);
            filteredWords = filteredWords.Where(w => regex.IsMatch(w));

            return filteredWords.OrderBy(w => w).ToList();
        }
    }
}