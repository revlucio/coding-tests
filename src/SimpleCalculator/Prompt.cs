
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
            _console.WriteLine("Enter a number: ");
            var firstNumber = _console.Read();

            if (!_validator.IsValidNumber(firstNumber))
            {
                _console.WriteLine("Invalid input please restart");
                return;
            }
            
            _console.WriteLine("Enter another number: ");
            var secondNumber = _console.Read();

            if (!_validator.IsValidNumber(secondNumber))
            {
                _console.WriteLine("Invalid input please restart");
                return;
            }

            _console.WriteLine("Enter an operator (+ or -): ");
            var operation = _console.Read();

            if (!_validator.IsValidOperation(operation))
            {
                _console.WriteLine("Invalid input please restart");
                return;
            }

            var result = _calculator.Parse(firstNumber, secondNumber, operation);
            _console.WriteLine("Result: {0}", result);
        }
    }
}