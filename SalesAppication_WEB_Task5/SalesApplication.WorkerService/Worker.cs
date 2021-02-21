using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SalesApplication.WorkerService
{
    using System.Configuration;
    using BLL;
    using BLL.CSVFileReader;
    using BLL.Models;
    using BLL.Services;
    using ConsoleApplication;
    using DAL;

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
                    new SaleInfoProcessor(new OrderService(ordersDbContext, new ProductService(ordersDbContext),
                        new ClientService(ordersDbContext), new ManagerService(ordersDbContext)))))
                    fileWatcher.StartWatching();
            }
            catch(Exception e)
            {
                _logger.LogError(e, " error ");
            }
        }
    }
}
