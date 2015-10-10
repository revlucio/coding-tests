using System.Collections.Generic;

namespace WordSearch
{
    public interface IWordLoader
    {
        List<string> GetWordsFromUrl();
    }
}