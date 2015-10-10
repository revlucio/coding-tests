using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace WordSearch
{
    public class WordLoader : IWordLoader
    {
        private string _url;

        public WordLoader(string url)
        {
            _url = url;
        }

        public List<string> GetWordsFromUrl()
        {
            try
            {
                var contents = new WebClient().DownloadString(_url);
                var words = contents.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                return words.ToList();
            }
            catch (WebException)
            {
                return new List<string>();
            }
        }
    }
}