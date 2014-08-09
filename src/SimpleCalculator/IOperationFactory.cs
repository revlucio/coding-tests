using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    public interface IOperationFactory
    {
        List<string> ValidOperations { get; }
        Dictionary<string, Func<int, int, int>> Operations { get; }
    }
}