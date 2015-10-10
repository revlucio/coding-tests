using System.Collections.Generic;

namespace WordCount.Tests
{
    public static class StringExtensions
    {
        public static bool IsComposedOfTwoWordsFromList(this string word, IList<string> words)
        {
            for (var i = 1; i < 6; i++)
            {
                if (words.Contains(word.Substring(0, i)) && words.Contains(word.Substring(i)))
                    return true;
            }

            return false;
        }
    }
}