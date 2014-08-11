using FakeItEasy;
using NUnit.Framework;
using System.Collections.Generic;

namespace WordSearch.Tests
{
    [TestFixture]
    public class WordSearcherTests
    {
        private WordSearcher _wordSearcher;

        [SetUp]
        public void BeforeEachTest()
        {
            var words = new List<string>() { "a", "ab", "abc", "aef", "ah", "abcd", "acb" };
            var wordLoader = A.Fake<IWordLoader>();
            A.CallTo(() => wordLoader.GetWordsFromUrl()).Returns(words);
            _wordSearcher = new WordSearcher(wordLoader, new RegexBuilder());
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 1)]
        public void GetMatchingWords_FiltersByLength(int length, int expectedMatches)
        {
            var matches = _wordSearcher.FindMatches(length, "a");

            Assert.That(matches, Has.Count.EqualTo(expectedMatches));
        }

        [Test]
        public void GetMatchingWords_FiltersBySearchWord()
        {
            var matches = _wordSearcher.FindMatches(3, "ab");

            Assert.That(matches, Has.Count.EqualTo(2));
        }

        [Test]
        public void GetMatchingWords_IsOrderedAlphabetically()
        {
            var expectedOrder = new List<string>() {"abc", "acb", "aef"};
            var matches = _wordSearcher.FindMatches(3, "a");
            
            Assert.That(matches, Is.EqualTo(expectedOrder));
        }
    }
}
