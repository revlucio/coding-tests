using System.IO;

namespace WordCount.UI
{
    public class FileWrapper : IFileWrapper
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}