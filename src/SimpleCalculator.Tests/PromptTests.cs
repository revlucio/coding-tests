using FakeItEasy;
using NUnit.Framework;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class PromptTests
    {
        private IConsole _console;
        private Prompt _prompt;
        private ICalculator _calculator;

        private void SetupConsole(params string[] consoleInputs)
        {
            A.CallTo(() => _console.Read()).ReturnsNextFromSequence(consoleInputs);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _console = A.Fake<IConsole>();
            _calculator = A.Fake<ICalculator>();
            _prompt = new Prompt(_console, _calculator);
        }

        [Test]
        public void Run__WhenFirstCalled_ShouldPromptForFirstNumber()
        {
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Enter a number: ")).MustHaveHappened();
        }

        [Test]
        public void Run_WhenFirstCalled_ShouldReadFirstNumber()
        {
            _prompt.Run();

            A.CallTo(() => _console.Read()).MustHaveHappened();
        }

        [Test]
        public void Run_AfterFirstNumberEntered_ShouldPromptForSecondNumber()
        {
            A.CallTo(() => _console.Read()).Returns("2");
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Enter another number: ")).MustHaveHappened();
        }

        [Test]
        public void Run_AfterFirstNumberEntered_ShouldReadSecondNumber()
        {
            A.CallTo(() => _console.Read()).Returns("2").Once();
            _prompt.Run();

            A.CallTo(() => _console.Read()).MustHaveHappened(Repeated.Exactly.Twice);
        }

        [Test]
        public void Run_AfterSecondNumberEntered_ShouldPromptForOperator()
        {
            SetupConsole("2", "3");
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Enter an operator (+ or -): ")).MustHaveHappened();
        }

        [Test]
        public void Run_AfterSecondNumberEntered_ShouldReadOperator()
        {
            SetupConsole("2", "3");
            _prompt.Run();

            A.CallTo(() => _console.Read()).MustHaveHappened(Repeated.Exactly.Times(3));
        }

        [Test]
        public void Run_AfterOperatorEntered_ShouldCallCalculator()
        {
            SetupConsole("2", "3", "+");
            _prompt.Run();

            A.CallTo(() => _calculator.Parse("2", "3", "+")).MustHaveHappened();
        }

        [Test]
        public void Run_AfterAdditionOperatorEntered_ShouldOutputResult()
        {
            SetupConsole("2", "3", "+");
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Result: 5")).MustHaveHappened();
        }

        [Test]
        public void Run_AfterSubtractionOperatorEntered_ShouldOutputResult()
        {
            SetupConsole("3", "2", "1");
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Result: 1")).MustHaveHappened();
        }
    }
}
