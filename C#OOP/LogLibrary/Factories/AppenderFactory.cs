using LogLibrary.Common;
using LogLibrary.Models.Appenders;
using LogLibrary.Models.Contracts;
using LogLibrary.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogLibrary.Factories
{
    public class AppenderFactory
    {
        public AppenderFactory()
        {

        }
        public IAppender CreateAppender(string appenderType,
            ILayout layout, Level level, IFile file = null)
        {
            IAppender appender;
            if (appenderType == nameof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (appenderType == nameof(FileAppender) && file != null)
            {
                appender = new FileAppender(layout, level, file);
            }
            else
            {
                throw new InvalidOperationException(
                    GlobalConstants.InvalidAppenderType);
            }
            return appender;
        }
    }
}
