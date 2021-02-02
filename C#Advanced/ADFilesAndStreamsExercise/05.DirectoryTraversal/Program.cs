using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../");
            Dictionary<string, List<FileInfo>> folderFiles = new Dictionary<string, List<FileInfo>>();
            foreach (var file in files)
            {
                FileInfo currentFile = new FileInfo(file);
                if (!folderFiles.ContainsKey(currentFile.Extension))
                {
                    folderFiles.Add(currentFile.Extension, new List<FileInfo>());
                }
                folderFiles[currentFile.Extension].Add(currentFile);
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using StreamWriter writer = new StreamWriter(@$"{path}\reportSecond.txt", true);
            foreach (var item in folderFiles
                .OrderByDescending(x => x.Value.Count)
               .ThenBy(x => x.Key))
            {
                writer.WriteLine(item.Key);
                foreach (var file in item.Value.OrderBy(x => x.Length))
                {
                    writer.WriteLine($"--{file.Name} - {file.Length / 1024.0:f3}kb");
                }
            }
        }
    }
}
