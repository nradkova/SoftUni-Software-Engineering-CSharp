using System;
using System.Collections.Generic;

using LogLibrary.Core;
using LogLibrary.Common;
using LogLibrary.Models;
using LogLibrary.Factories;
using LogLibrary.Models.Files;
using LogLibrary.IOManagement;
using LogLibrary.Core.Contracts;
using LogLibrary.Models.Contracts;
using LogLibrary.Models.Enumerations;
using LogLibrary.IOManagement.Contracts;
using LogLibrary.Models.PathManagement;

namespace LogLibrary
{
   public class StartUp
    {
        private static LayoutFactory layoutFactory 
            = new LayoutFactory();
        private static AppenderFactory appenderFactory 
            = new AppenderFactory();
       
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IPathManager pathManager 
                = new PathManager("logs", "log.txt");
            IFile file = new LogFile(pathManager);

            int n =int.Parse(reader.ReadLine());

            ILogger logger = SetUpLogger(n, reader, writer, file);

            IEngine engine = new Engine(logger, reader, writer);
            engine.Run();
        }

        private static ILogger SetUpLogger(int appendersCount,
            IReader reader,IWriter writer,IFile file)
        {
            ICollection<IAppender> appenders = new HashSet<IAppender>();
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersArgs = reader.ReadLine()
                    .Split();
                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];

                bool hasError = false;
                Level level = ParseLevel(appendersArgs, writer, ref hasError);
                if (hasError)
                {
                    continue;
                }

                try
                {
                    ILayout layout = layoutFactory
                        .CreateLayout(layoutType);
                    IAppender appender = appenderFactory
                        .CreateAppender(appenderType,
                        layout,level,file);
                    appenders.Add(appender);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
            }
            ILogger logger = new Logger(appenders);
            return logger;
        }
        private static Level ParseLevel(string []levelStr,
            IWriter writer, ref bool hasError)
        {
            Level appenderLevel = Level.INFO;
            if (levelStr.Length == 3)
            {
                bool isEnumValid
                    = Enum.TryParse(typeof(Level),
                   levelStr[2], true,
                   out object enumParsed);
                if (!isEnumValid)
                {
                    writer.Write(GlobalConstants.InvalidLevelType);
                    hasError = true;
                }
                appenderLevel = (Level)enumParsed;
            }
            return appenderLevel;
        }
    }
}
