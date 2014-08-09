
namespace SimpleCalculator
{
    public class Calculator : ICalculator
    {
        public int Parse(int x, int y, string operation)
        {
            switch (operation)
            {
                case "+":
                    return x + y;
                case "-":
                    return x - y;
            }

            return 0;
        }
    }
}