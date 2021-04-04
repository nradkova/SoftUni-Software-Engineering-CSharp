namespace LogLibrary.Models.Contracts
{
   public interface IPathManager
    {
        string CurrentDirectoryPath { get; }
        string CurrentFilePath { get; }
        string GetCurrentPath();
        void EnsureDirectoryAndFileExist();
    }
}
