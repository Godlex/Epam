namespace SalesApplication.ConsoleApplication
{
    using System;
    using System.IO;
    using BLL;
    using BLL.FileWatcher;
    using BLL.Services;

    public class FileWatcher : IDisposable, IFileWatcher
    {
        private readonly SaleInfoProcessor _saleInfoProcessor;
        
        private readonly ICsvFileReader _fileReader;

        private readonly FileSystemWatcher _fileSystemWatcher;

        public FileWatcher(ICsvFileReader fileReader, string salesDirPath, SaleInfoProcessor saleInfoProcessor)
        {
            _fileReader = fileReader;
            
            _fileSystemWatcher = new FileSystemWatcher();

            _saleInfoProcessor = saleInfoProcessor;
            
            _fileSystemWatcher.Created += FileSystemWatcher_Created;

            _fileSystemWatcher.Path = salesDirPath;

            _fileSystemWatcher.Filter = "*.csv";

        }

        public void StartWatching()
        {
            Console.WriteLine("Govno");
            _fileSystemWatcher.EnableRaisingEvents = true;
            Console.ReadKey();
        }
        public void StopWatching()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("I am nash`l fail");
            var saleInfos = _fileReader.Read(e.FullPath);
            _saleInfoProcessor.Processes(saleInfos,e.Name);
        }

        public void Dispose()
        {
            _fileSystemWatcher?.Dispose();
        }
    }
}