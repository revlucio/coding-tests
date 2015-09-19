using System.Linq;

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
            var words = _fileWrapper.ReadAllText(filename)
                .ToLower().Replace(".", "").Replace("!", "").Replace(",", "").Replace("?", "")
                .Split(' ')
                .OrderBy(s => s);
            
            var report = string.Empty;
            foreach (var word in words.Distinct())
            {
                report += word + " " + words.Count(s => s == word) + "\n";
            }
                
            return report.Trim();
    }
    }
}