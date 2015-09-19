using System;

namespace WordCount.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordCounter = new WordCounter(new FileWrapper());
            Console.WriteLine(wordCounter.RunReport(args[0]));
        }
    }
}
