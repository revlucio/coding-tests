namespace WordCount.UI
{
    public interface IFileWrapper
    {
        bool Exists(string path);
        string ReadAllText(string path);
    }
}