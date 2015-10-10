using System;

namespace SimpleCalculator
{
    public class ConsoleWrapper : IConsole
    {
        public void WriteLine(string msg, params object[] args)
        {
            Console.WriteLine(msg, args);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}