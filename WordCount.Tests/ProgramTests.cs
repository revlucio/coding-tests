using System.Linq;
using FakeItEasy;
using NUnit.Framework;

namespace WordCount.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void GivenFileName_WhenDoesntExist_ReturnsEmpty()
        {
            // arrange
            var wordCounter = new WordCounter(new FileWrapper());

            // act
            var result = wordCounter.RunReport("badfile.txt");

            // assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void GivenFileName_WhenExists_ReturnsResult()
        {
            // arrange
            var fileMock = A.Fake<IFileWrapper>();
            A.CallTo(() => fileMock.Exists(A<string>._)).Returns(true);
            A.CallTo(() => fileMock.GetConent(A<string>._)).Returns("test");
            var wordCounter = new WordCounter(fileMock);

            // act
            var result = wordCounter.RunReport("goodfile.txt");

            // assert
            Assert.That(result, Is.Not.Empty);
        }

        [TestCase("A simple sentence", "a 1 sentence 1 simple 1")]
        [TestCase("A simple, sentence. Simple!", "a 1 sentence 1 simple 2")]
        [TestCase("Another simple sentence", "another 1 sentence 1 simple 1")]
        [TestCase("A simple repeat repeat", "a 1 repeat 2 simple 1")]
        [TestCase("How much wood would a wood chuck chuck if a wood chuck could chuck wood", "a 2 chuck 4 could 1 how 1 if 1 much 1 wood 4 would 1")]
        public void GivenFileName_WhenHasContent_ReturnsReport(string content, string expected)
        {
            // arrange
            var fileMock = A.Fake<IFileWrapper>();
            A.CallTo(() => fileMock.Exists(A<string>._)).Returns(true);
            A.CallTo(() => fileMock.GetConent(A<string>._)).Returns(content);
            var wordCounter = new WordCounter(fileMock);

            // act
            var result = wordCounter.RunReport("goodfile.txt");

            // assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GivenFileName_WhenFileExistsOnDisk_ReturnsReport()
        {
            // arrange
            var wordCounter = new WordCounter(new FileWrapper());

            // act
            var result = wordCounter.RunReport("woodchuck.txt");

            // assert
            var expected = "a 2 chuck 4 could 1 how 1 if 1 much 1 wood 4 would 1";
            Assert.That(result, Is.EqualTo(expected));
        }
    }

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
                var words = FileWrapper.GetConent(filename)
                    .ToLower().Replace('.', ' ').Replace('!', ' ').Replace(',', ' ')
                    .Split(' ')
                    .Select(word  => word.Trim())
                    .Where(word => word.Length > 0)
                    .OrderBy(s => s);
            
                var report = "";
                foreach (var word in words.Distinct())
                {
                    report += word + " " + words.Count(s => s==word) + " ";
                }
                
                return report.Trim();
            }

            return "";
        }
    }
}
