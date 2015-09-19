using System;
using System.IO;

namespace WordCount.Tests
{
    public class FileWrapper : IFileWrapper
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string GetConent(string path)
        {
            throw new NotImplementedException();
        }
    }
}