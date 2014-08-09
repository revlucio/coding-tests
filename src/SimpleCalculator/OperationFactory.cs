using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public class OperationFactory : IOperationFactory
    {
        private readonly List<string> _validOperations = new List<string> { "+", "-" };
        private readonly Dictionary<string, Func<int, int, int>> _operations = new Dictionary<string, Func<int, int, int>>();

        public OperationFactory()
        {
            _operations.Add("+", (x, y) => x + y);
            _operations.Add("-", (x, y) => x - y);
        }

        public List<string> ValidOperations { get { return _validOperations; } }
        public Dictionary<string, Func<int, int, int>> Operations { get { return _operations; } }
    }
}