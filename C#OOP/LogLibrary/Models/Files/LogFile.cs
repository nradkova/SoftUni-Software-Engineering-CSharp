using System;
using System.IO;
using System.Linq;

using LogLibrary.Common;
using LogLibrary.Models.Contracts;
using LogLibrary.Models.Enumerations;

namespace LogLibrary.Models.Files
{
    public class LogFile : IFile
    {
        private readonly IPathManager pathManager;

        public LogFile(IPathManager pathManager)
        {
            this.pathManager = pathManager;
            this.pathManager.EnsureDirectoryAndFileExist();
        }

        public string Path
            => pathManager.CurrentFilePath;
        public long Size
            => CalculateFileSize();

        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMsg
                = String.Format(format,
                dateTime.ToString(GlobalConstants.DateTimeFormatted),
                level.ToString(), message);

            return formattedMsg;
        }

        private long CalculateFileSize()
        {
            string text = File.ReadAllText(Path);

            return text
                .Where(c => char.IsLetter(c))
                .Sum(c => c);
        }
    }
}
