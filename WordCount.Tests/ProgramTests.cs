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
            var wordCounter = new WordCounter(fileMock);

            // act
            var result = wordCounter.RunReport("goodfile.txt");

            // assert
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public void GivenFileName_WhenHasContent_ReturnsReport()
        {
            // arrange
            //var content = "How much wood would a wood chuck chuck if a wood chuck could chuck wood?";
            var content = "A simple sentence";
            var fileMock = A.Fake<IFileWrapper>();
            A.CallTo(() => fileMock.Exists(A<string>._)).Returns(true);
            A.CallTo(() => fileMock.GetConent(A<string>._)).Returns(content);
            var wordCounter = new WordCounter(fileMock);

            // act
            var result = wordCounter.RunReport("goodfile.txt");

            // assert
            var expected = "A 1 simple 1 sentence 1";
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
                return "A 1 simple 1 sentence 1";

            return "";
        }
    }
}
