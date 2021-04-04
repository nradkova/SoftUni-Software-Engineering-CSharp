using LogLibrary.Models.Enumerations;

namespace LogLibrary.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }
        Level Level { get; }
        void Append(IError error);
    }
}
