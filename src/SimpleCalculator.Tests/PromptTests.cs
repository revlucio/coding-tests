using FakeItEasy;
using NUnit.Framework;

namespace SimpleCalculator.Tests
{
    [TestFixture]
    public class PromptTests
    {
        private IConsole _console;
        private Prompt _prompt;

        private void SetupConsole(params string[] consoleInputs)
        {
            A.CallTo(() => _console.Read()).ReturnsNextFromSequence(consoleInputs);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _console = A.Fake<IConsole>();
            _prompt = new Prompt(_console, new Calculator(), new Validator());
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
        public void Run_AfterFirstNumberEntered_IfInvalidWritesMessage()
        {
            A.CallTo(() => _console.Read()).Returns("x");
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Invalid input please restart")).MustHaveHappened();
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
        public void Run_AfterSecondNumberEntered_IfInvalidWritesMessage()
        {
            SetupConsole("2", "x");
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Invalid input please restart")).MustHaveHappened();
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
        public void Run_AfterOperatorEntered_IfInvalidWritesMessage()
        {
            SetupConsole("2", "4", "x");
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Invalid input please restart")).MustHaveHappened();
        }

        [TestCase("2", "3", "+", 5)]
        [TestCase("3", "2", "-", 1)]
        public void Run_AfterOperatorEntered_ShouldOutputResult(string num1, string num2, string operation, int expectedResult)
        {
            SetupConsole("2", "3", "+");
            _prompt.Run();

            A.CallTo(() => _console.WriteLine("Result: {0}", new object[] {5})).MustHaveHappened();
        }
    }
}
