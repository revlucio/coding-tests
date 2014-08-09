namespace SimpleCalculator
{
    public interface IValidator
    {
        int? ToValidNumber(string input);
        bool IsValidOperation(string operation);
    }
}