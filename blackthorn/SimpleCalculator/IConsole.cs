namespace SimpleCalculator
{
    public interface IConsole
    {
        void WriteLine(string msg, params object[] args);
        string Read();
    }
}