using System;

using LogLibrary.Common;
using LogLibrary.IOManagement;
using LogLibrary.Models.Contracts;
using LogLibrary.Models.Enumerations;
using LogLibrary.IOManagement.Contracts;

namespace LogLibrary.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        private readonly IWriter writer;

        public ConsoleAppender(ILayout layout, Level level)
            :base(layout,level)
        {
            writer = new ConsoleWriter();
        }

        public override void Append(IError error)
        {
            string format = Layout.Format;
            DateTime dateTime = error.DateTime;
            string message = error.Message;
            Level level = error.Level;

            string formattedMsg
                = String.Format(format,
                dateTime.ToString(GlobalConstants.DateTimeFormatted),
                level.ToString(), message);

            writer.WriteLine(formattedMsg);
            messagesAppended++;
        }
        public override string ToString()
        {
            string msg =
                 $"Appender type: {this.GetType().Name}," +
                 $" Layout type: {Layout.GetType().Name}, " +
                 $"Report level: {Level.ToString()}, " +
                 $"Messages appended: {messagesAppended}";
            return msg;
        }
    }
}
