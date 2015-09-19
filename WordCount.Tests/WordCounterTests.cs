using System.IO;
using FakeItEasy;
using NUnit.Framework;
using WordCount.UI;

namespace WordCount.Tests
{
    [TestFixture]
    public class WordCounterTests
    {
        [TestCase("A simple sentence", "a 1\nsentence 1\nsimple 1")]
        [TestCase("A simple, sentence. Simple! Simple?", "a 1\nsentence 1\nsimple 3")]
        [TestCase("Another simple sentence", "another 1\nsentence 1\nsimple 1")]
        [TestCase("A simple repeat repeat", "a 1\nrepeat 2\nsimple 1")]
        [TestCase("How much wood would a wood chuck chuck if a wood chuck could chuck wood", "a 2\nchuck 4\ncould 1\nhow 1\nif 1\nmuch 1\nwood 4\nwould 1")]
        public void GivenFileName_WhenHasContent_ReturnsReport(string content, string expected)
        {
            // arrange
            var fileMock = A.Fake<IFileWrapper>();
            A.CallTo(() => fileMock.ReadAllText(A<string>._)).Returns(content);
            var wordCounter = new WordCounter(fileMock);

            // act
            var result = wordCounter.RunReport("goodfile.txt");

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GivenFileName_WhenDoesntExist_ReturnsEmpty()
        {
            // arrange
            var wordCounter = new WordCounter(new FileWrapper());

            // act
            // assert
            Assert.Throws<FileNotFoundException>(() => wordCounter.RunReport("badfile.txt"));
        }

        [Test]
        public void GivenFileName_WhenFileExistsOnDisk_ReturnsReport()
        {
            // arrange
            var wordCounter = new WordCounter(new FileWrapper());

            // act
            var result = wordCounter.RunReport("woodchuck.txt");

            // assert
            var expected = "a 2\nchuck 4\ncould 1\nhow 1\nif 1\nmuch 1\nwood 4\nwould 1";
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("A simpleton sentence", "")]
        [TestCase("A lbums albums", "albums")]
        [TestCase("Al bums albums", "albums")]
        [TestCase("Alb ums albums", "albums")]
        [TestCase("Albu ms albums", "albums")]
        [TestCase("Album s albums", "albums")]
        [TestCase("Albums albums", "")]
        [TestCase("Bare ly barely Al bums albums", "albums\nbarely")]
        [TestCase(
            "al, albums, aver, bar, barely, be, befoul, bums, by, cat, con, convex, ely, foul, here, hereby, jig, jigsaw, or, saw, tail, tailor, vex, we, weaver",
            "albums\nbarely\nbefoul\nconvex\nhereby\njigsaw\ntailor\nweaver")]
        public void GivenFileNameToFilter_WhenHasContent_ReturnsFilteredList(string content, string expected)
        {
            // arrange
            var fileMock = A.Fake<IFileWrapper>();
            A.CallTo(() => fileMock.ReadAllText(A<string>._)).Returns(content);
            var wordFilter = new WordCounter(fileMock);

            // act
            var result = wordFilter.GetFilteredWords("goodfile.txt");

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
