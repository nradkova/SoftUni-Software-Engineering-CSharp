using LogLibrary.Models.Contracts;
using LogLibrary.Models.Enumerations;

namespace LogLibrary.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected int messagesAppended;
        protected Appender(ILayout layout, Level level)
        {
            Layout = layout;
            Level = level;
        }

        public ILayout Layout { get; }

        public Level Level { get; }

        public abstract void Append(IError error);

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
