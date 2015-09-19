using System.Collections.Generic;
using System.Linq;
using WordCount.Tests;

namespace WordCount.UI
{
    public class WordCounter
    {
        private readonly IFileWrapper _fileWrapper;

        public WordCounter(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public string RunReport(string filename)
        {
            var words = GetWords(filename);

            var report = string.Empty;
            foreach (var word in words.Distinct())
            {
                report += word + " " + words.Count(s => s == word) + "\n";
            }
                
            return report.Trim();
        }

        public string GetFilteredWords(string filename)
        {
            var words = GetWords(filename);

            var report = string.Empty;
            foreach (var word in words.Where(word => word.Length == 6 && word.IsComposedOfTwoWordsFromList(words)))
            {
                report += word + "\n";
            }
            return report.Trim();
        }

        private List<string> GetWords(string filename)
        {
            var words = _fileWrapper.ReadAllText(filename)
                .ToLower().Replace(".", "").Replace("!", "").Replace(",", "").Replace("?", "")
                .Split(' ')
                .OrderBy(word => word)
                .ToList();
            return words;
        }
    }
}