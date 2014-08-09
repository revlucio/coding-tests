
namespace SimpleCalculator
{
    public class Calculator : ICalculator
    {
        public int Parse(string x, string y, string operation)
        {
            var val1 = int.Parse(x);
            var val2 = int.Parse(y);

            switch (operation)
            {
                case "+":
                    return val1 + val2;
                case "-":
                    return val1 - val2;
            }

            return 0;
        }
    }
}