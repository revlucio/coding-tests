namespace SimpleCalculator
{
    public interface IValidator
    {
        bool IsValidNumber(string input);
        bool IsValidOperation(string operation);
    }
}