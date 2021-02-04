using System;

namespace SalesApplication.ConsoleApplication
{
    using System.Configuration;
    using System.Data.Entity;
    using BLL;
    using BLL.CSVFileReader;
    using BLL.Services;
    using DAL;

    class Program
    {
        static void Main(string[] args)
        {
            string path = ConfigurationManager.AppSettings["SaleInfoDirPath"];
            OrdersBDContext ordersBdContext = new OrdersBDContext("SalesDB");
            using (FileWatcher fileWatcher = new FileWatcher(new CsvFileReader(), path,
                new SaleInfoProcessor(new OrderService(ordersBdContext, new ProductService(ordersBdContext),
                    new ClientService(ordersBdContext), new ManagerService(ordersBdContext)))))
                fileWatcher.StartWatching();
        }
    }
}