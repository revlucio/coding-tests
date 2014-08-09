
namespace SimpleCalculator
{
    public class Prompt
    {
        private readonly IConsole _console;
        private readonly ICalculator _calculator;
        private readonly IValidator _validator;

        public Prompt(IConsole console, ICalculator calculator, IValidator validator)
        {
            _console = console;
            _calculator = calculator;
            _validator = validator;
        }

        private string ReadNumber(string inputMessage)
        {
            _console.WriteLine(inputMessage);
            var number = _console.Read();

            if (_validator.IsValidNumber(number)) 
                return number;

            _console.WriteLine("Invalid input please restart");
            return null;
        }

        private string ReadOperation(string inputMessage)
        {
            _console.WriteLine(inputMessage);
            var operation = _console.Read();

            if (_validator.IsValidOperation(operation))
                return operation;

            _console.WriteLine("Invalid input please restart");
            return null;
        }

        public void Run()
        {
            var firstNumber = ReadNumber("Enter a number: ");
            if (firstNumber == null) return;

            var secondNumber = ReadNumber("Enter another number: ");
            if (secondNumber == null) return;

            var operation = ReadOperation("Enter an operator (+ or -): ");
            if (operation == null) return;

            var result = _calculator.Parse(firstNumber, secondNumber, operation);
            _console.WriteLine("Result: {0}", result);
        }
    }
}