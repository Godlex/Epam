namespace SalesApplication.BLL.FileWatcher
{
    public interface IFileWatcher
    {
        void StartWatching();
        void StopWatching();
    }
}