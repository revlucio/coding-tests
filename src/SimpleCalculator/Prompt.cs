using System;

namespace SimpleCalculator
{
    public class Prompt
    {
        private readonly IConsole _console;
        private readonly ICalculator _calculator;

        public Prompt(IConsole console, ICalculator calculator)
        {
            _console = console;
            _calculator = calculator;
        }

        public void Run()
        {
            _console.WriteLine("Enter a number: ");
            var firstNumber = _console.Read();

            if (String.IsNullOrWhiteSpace(firstNumber)) return;
            
            _console.WriteLine("Enter another number: ");
            var secondNumber = _console.Read();

            if (String.IsNullOrWhiteSpace(secondNumber)) return;

            _console.WriteLine("Enter an operator (+ or -): ");
            var operation = _console.Read();

            if (String.IsNullOrWhiteSpace(operation)) return;

            var result = _calculator.Parse(firstNumber, secondNumber, operation);
            _console.WriteLine("Result: {0}", result);
        }
    }
}