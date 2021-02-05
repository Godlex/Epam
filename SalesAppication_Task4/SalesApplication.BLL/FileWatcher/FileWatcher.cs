namespace SalesApplication.ConsoleApplication
{
    using System;
    using System.IO;
    using BLL;
    using BLL.CSVFileReader;
    using BLL.FileWatcher;
    using BLL.Models;
    using BLL.Services;

    public class FileWatcher : IDisposable, IFileWatcher
    {
        private readonly SaleInfoProcessor _saleInfoProcessor;
        
        private readonly ICsvFileReader<SalesInfoMap,SalesInfo> _fileReader;

        private readonly FileSystemWatcher _fileSystemWatcher;

        private bool _isWathing;

        public FileWatcher(ICsvFileReader<SalesInfoMap,SalesInfo> fileReader, string salesDirPath, SaleInfoProcessor saleInfoProcessor)
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
            _fileSystemWatcher.EnableRaisingEvents = true;
            _isWathing = true;
            while (_isWathing);
        }
        public void StopWatching()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
            _isWathing = false;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            var saleInfos = _fileReader.Read(e.FullPath);
            var managerSecondName = GetManagerSecondNameFromFileName(e.Name);
            _saleInfoProcessor.Processes(saleInfos,managerSecondName);
        }

        private string GetManagerSecondNameFromFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));
            const int redundantSymbol = 13;
            return fileName[..^redundantSymbol];

        }
        public void Dispose()
        {
            _fileSystemWatcher?.Dispose();
        }
    }
}