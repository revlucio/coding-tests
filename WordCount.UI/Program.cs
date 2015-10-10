using System;

namespace WordCount.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordCounter = new WordReporter(new FileWrapper());

            if (args[1] == "count")
                Console.WriteLine(wordCounter.GetWordCounts(args[0]));

            if (args[1] == "filter")
                Console.WriteLine(wordCounter.GetFilteredWords(args[0]));
        }
    }
}
