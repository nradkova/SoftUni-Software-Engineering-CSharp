using LogLibrary.IOManagement;
using LogLibrary.Models.Contracts;
using LogLibrary.Models.Enumerations;
using LogLibrary.IOManagement.Contracts;

namespace LogLibrary.Models.Appenders
{
    public class FileAppender : Appender
    {
        private readonly IWriter writer;
        public FileAppender(ILayout layout, Level level,IFile file)
            :base(layout,level)
        {
            File = file;
            writer = new FileWriter(File.Path);
        }

        public IFile File { get; }

        public override void Append(IError error)
        {
            string formattedMsg = File.Write(Layout, error);
            writer.WriteLine(formattedMsg);
            messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {File.Size}";
        }
    }
}
