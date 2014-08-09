using System.Collections.Generic;

namespace SimpleCalculator
{
    public class OperationFactory : IOperationFactory
    {
        private List<string> _validOperations = new List<string> { "+", "-" };

        public List<string> ValidOperations { get { return _validOperations; } }
    }
}