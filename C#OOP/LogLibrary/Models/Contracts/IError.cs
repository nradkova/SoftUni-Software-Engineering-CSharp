using System;

using LogLibrary.Models.Enumerations;

namespace LogLibrary.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }
        string Message { get; }
        Level Level { get; }

    }
}
