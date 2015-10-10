using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    public class OperationFactory : IOperationFactory
    {
        private readonly Dictionary<string, Func<int, int, int>> _operations;

        public OperationFactory()
        {
            _operations = new Dictionary<string, Func<int, int, int>>
            {
                {"+", (x, y) => x + y},
                {"-", (x, y) => x - y}
            };
        }

        public List<string> ValidOperations
        {
            get { return _operations.Keys.ToList(); }
        }

        public Dictionary<string, Func<int, int, int>> Operations
        {
            get { return _operations; }
        }
    }
}