using System.Linq;

namespace WordCount.UI
{
    public class WordCounter
    {
        public IFileWrapper FileWrapper { get; set; }

        public WordCounter(IFileWrapper fileWrapper)
        {
            FileWrapper = fileWrapper;
        }

        public string RunReport(string filename)
        {
            if (FileWrapper.Exists(filename))
            {
                var words = FileWrapper.ReadAllText(filename)
                    .ToLower().Replace('.', ' ').Replace('!', ' ').Replace(',', ' ').Replace('?', ' ')
                    .Split(' ')
                    .Select(word  => word.Trim())
                    .Where(word => word.Length > 0)
                    .OrderBy(s => s);
            
                var report = "";
                foreach (var word in words.Distinct())
                {
                    report += word + " " + words.Count(s => s==word) + "\n";
                }
                
                return report.Trim();
            }

            return "";
        }
    }
}