

namespace SimpleCalculator
{
    public class Calculator : ICalculator
    {
        private readonly IOperationFactory _operationFactory;

        public Calculator(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public int Parse(int x, int y, string operation)
        {
            return _operationFactory.Operations.ContainsKey(operation) 
                ? _operationFactory.Operations[operation](x, y) 
                : 0;
        }
    }
}