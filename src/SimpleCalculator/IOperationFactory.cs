using System.Collections.Generic;

namespace SimpleCalculator
{
    public interface IOperationFactory
    {
        List<string> ValidOperations { get; } 
    }
}