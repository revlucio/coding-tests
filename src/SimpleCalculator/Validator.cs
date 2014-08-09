using System.Linq;

namespace SimpleCalculator
{
    public class Validator : IValidator
    {
        private readonly IOperationFactory _operationFactory;
        
        public Validator(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        /// <summary>
        /// Tries to parse to an int and returns null if it can't
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int? ToValidNumber(string input)
        {
            int result;
            return int.TryParse(input, out result) ? (int?)result : null;
        }

        public bool IsValidOperation(string operation)
        {
            return _operationFactory.ValidOperations.Any(o => o == operation);
        }
    }
}