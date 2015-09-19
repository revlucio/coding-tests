namespace WordCount.Tests
{
    public interface IFileWrapper
    {
        bool Exists(string path);
        string GetConent(string path);
    }
}