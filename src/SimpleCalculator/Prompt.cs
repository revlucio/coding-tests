namespace SimpleCalculator
{
    public class Prompt
    {
        private readonly IConsole _console;
        private readonly ICalculator _calculator;
        private readonly IValidator _validator;
        private readonly ILogger _logger;

        public Prompt(IConsole console, ICalculator calculator, IValidator validator, ILogger logger)
        {
            _console = console;
            _calculator = calculator;
            _validator = validator;
            _logger = logger;
        }

        public void Run()
        {
            _logger.Log("Calculator started");

            var firstNumber = ReadNumber("Enter a number: ");
            if (firstNumber == null) return;

            var secondNumber = ReadNumber("Enter another number: ");
            if (secondNumber == null) return;

            var operation = ReadOperation("Enter an operator (+ or -): ");
            if (operation == null) return;

            var result = _calculator.Parse(firstNumber.Value, secondNumber.Value, operation);
            _console.WriteLine("Result: {0}", result);

            _logger.Log(string.Format(
                "Calculator finished. User entered {0} {1} {2} and result was {3}",
                firstNumber, operation, secondNumber, result));
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