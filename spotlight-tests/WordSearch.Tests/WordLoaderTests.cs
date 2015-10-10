using NUnit.Framework;

namespace WordSearch.Tests
{
    [TestFixture]
    public class WordLoaderTests
    {
        [Test]
        public void GetWords_ReturnsWordsFromUrl()
        {
            var url = @"http://dl.dropboxusercontent.com/u/7543760/wordlist.txt";
            IWordLoader loader = new WordLoader(url);

            var words = loader.GetWordsFromUrl(); 

            Assert.That(words, Is.Not.Empty);
            Assert.That(words.Contains("bor"));
            Assert.That(words.Contains("walla's"));
        }

        [Test]
        public void GetWords_InvalidUrl_ReturnsEmptyList()
        {
            var url = @"http://fakesite.com/wordlist.txt";
            IWordLoader loader = new WordLoader(url);

            var words = loader.GetWordsFromUrl();

            Assert.That(words, Is.Empty);
        }
    }
}
