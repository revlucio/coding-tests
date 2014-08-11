
using System;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordSearcher = new WordSearcher(
                new WordLoader(@"http://dl.dropboxusercontent.com/u/7543760/wordlist.txt"),
                new RegexBuilder());

            var length = int.Parse(args[0]);
            var matchingWords = wordSearcher.FindMatches(length, args[1]);

            matchingWords.ForEach(Console.WriteLine);
        }
    }
}
