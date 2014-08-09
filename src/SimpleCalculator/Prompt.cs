

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

        public void Run()
        {
            var firstNumber = ReadNumber("Enter a number: ");
            if (firstNumber == null) return;

            var secondNumber = ReadNumber("Enter another number: ");
            if (secondNumber == null) return;

            var operation = ReadOperation("Enter an operator (+ or -): ");
            if (operation == null) return;

            var result = _calculator.Parse(firstNumber.Value, secondNumber.Value, operation);
            _console.WriteLine("Result: {0}", result);
        }

        private int? ReadNumber(string inputMessage)
        {
            _console.WriteLine(inputMessage);

            var number = _validator.ToValidNumber(_console.Read());

            if (number == null)
                _console.WriteLine("Invalid input please restart");

            return number;
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
    }
}