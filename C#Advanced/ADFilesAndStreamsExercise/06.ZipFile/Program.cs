using System;
using System.IO.Compression;

namespace _06.ZippedFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPath = @"../../../FileToZip";
            string zipPath = @"../../../ZippedFile";
            string extractPath = @"../../../ExtractedFile";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
