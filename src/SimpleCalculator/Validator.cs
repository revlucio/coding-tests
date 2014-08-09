namespace SimpleCalculator
{
    public class Validator : IValidator
    {
        public bool IsValidNumber(string input)
        {
            int result;
            return int.TryParse(input, out result);
        }

        public bool IsValidOperation(string operation)
        {
            if (operation == "+") return true;
            if (operation == "-") return true;

            return false;
        }
    }
}