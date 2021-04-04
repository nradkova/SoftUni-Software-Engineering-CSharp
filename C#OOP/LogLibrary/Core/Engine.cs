using System;

using LogLibrary.Common;
using System.Globalization;
using LogLibrary.Models.Errors;
using LogLibrary.Core.Contracts;
using LogLibrary.Models.Contracts;
using LogLibrary.IOManagement.Contracts;
using LogLibrary.Models.Enumerations;

namespace LogLibrary.Core
{
    public class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ILogger logger, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = string.Empty;
            while ((command = reader.ReadLine()) != "END")
            {
                string[] errorArgs = command.Split("|");
                string levelStr = errorArgs[0];
                string dateTimeStr = errorArgs[1];
                string message = errorArgs[2];

                bool isLevelValid
                    = Enum.TryParse(typeof(Level),
                   levelStr, true,
                   out object levelObj);
                if (!isLevelValid)
                {
                    writer.Write(GlobalConstants.InvalidLevelType);
                    continue;
                }
                Level appenderLevel = (Level)levelObj;

                bool isDateTimeValid = DateTime.TryParseExact
                    (dateTimeStr, GlobalConstants.DateTimeFormatted,
                    CultureInfo.InvariantCulture,DateTimeStyles.None,
                    out DateTime dateTime);
                if (!isDateTimeValid)
                {
                    writer.Write(GlobalConstants.InvalidDateTimeFormat);
                    continue;
                }
                IError error = new Error(dateTime, message, appenderLevel);
                logger.Log(error);
            }

            writer.WriteLine(logger.ToString());
        }
    }
}
