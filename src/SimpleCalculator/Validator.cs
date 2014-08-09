namespace SimpleCalculator
{
    public class Validator : IValidator
    {
        /// <summary>
        /// Tries to parse to an int and returns null if it can't
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int? ToValidNumber(string input)
        {
            int result;
            return int.TryParse(input, out result) ? (int?)result : null;
        }

        public bool IsValidOperation(string operation)
        {
            if (operation == "+") return true;
            if (operation == "-") return true;

            return false;
        }
    }
}