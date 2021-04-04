using System.Collections.Generic;

namespace LogLibrary.Models.Contracts
{
   public  interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
