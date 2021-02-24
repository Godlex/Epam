namespace SalesApplication.WorkerService
{
    using System;
    using System.Configuration;
    using System.Threading;
    using System.Threading.Tasks;
    using BLL;
    using BLL.CSVFileReader;
    using BLL.FileWatcher;
    using BLL.Models;
    using BLL.SaleInfoProcessor;
    using BLL.Services;
    using DAL;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["SaleInfoDirPath"];
                OrdersDbContext ordersDbContext = new OrdersDbContext("SalesDB");
                using (FileWatcher fileWatcher = new FileWatcher(new CsvFileReader<SalesInfoMap, SalesInfo>(), path,
                    new SaleInfoProcessor(new OrderService("SalesDB"))))
                    fileWatcher.StartWatching();
            }
            catch(Exception e)
            {
                _logger.LogError(e, " error ");
            }
        }
    }
}
