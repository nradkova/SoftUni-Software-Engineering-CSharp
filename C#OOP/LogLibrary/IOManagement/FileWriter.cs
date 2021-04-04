using System;
using System.IO;

using LogLibrary.IOManagement.Contracts;

namespace LogLibrary.IOManagement
{
    public class FileWriter : IWriter
    {
        public FileWriter(string path)
        {
            FilePath = path;
        }
        public string  FilePath { get; }
        public void Write(string text)
        {
            File.AppendAllText(FilePath, text);
        }

        public void WriteLine(string text)
        {
            File.AppendAllText(FilePath, text+Environment.NewLine);
        }
    }
}
