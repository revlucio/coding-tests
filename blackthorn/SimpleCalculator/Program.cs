
namespace SimpleCalculator
{
    public static class Program
    {
        public static void Main()
        {
            var prompt = new Prompt(new ConsoleWrapper(), new Calculator(new OperationFactory()), new Validator(new OperationFactory()), new FakeLogger());
            prompt.Run();
        }
    }
}
