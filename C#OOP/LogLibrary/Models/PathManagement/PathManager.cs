using System.IO;

using LogLibrary.Models.Contracts;

namespace LogLibrary.Models.PathManagement
{
    public class PathManager : IPathManager
    {
        private readonly string currentPath;
        private readonly string folderName;
        private readonly string fileName;

        private PathManager()
        {
            currentPath = GetCurrentPath();
        }

        public PathManager(string folderName, string fileName)
            : this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath
            => Path.Combine(currentPath, folderName);

        public string CurrentFilePath
            => Path.Combine(CurrentDirectoryPath, fileName);

        public void EnsureDirectoryAndFileExist()
        {
            if (!Directory.Exists(CurrentDirectoryPath))
            {
                Directory.CreateDirectory(CurrentDirectoryPath);
            }

            File.AppendAllText(CurrentFilePath, "");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
