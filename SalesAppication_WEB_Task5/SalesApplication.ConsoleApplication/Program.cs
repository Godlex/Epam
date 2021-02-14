namespace SalesApplication.ConsoleApplication
{
    using System;
    using System.Configuration;
    using System.Threading;
    using BLL;
    using BLL.CSVFileReader;
    using BLL.Models;
    using BLL.Services;
    using DAL;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["SaleInfoDirPath"];
                OrdersBDContext ordersBdContext = new OrdersBDContext("SalesDB");
                using (FileWatcher fileWatcher = new FileWatcher(new CsvFileReader<SalesInfoMap, SalesInfo>(), path,
                    new SaleInfoProcessor(new OrderService(ordersBdContext, new ProductService(ordersBdContext),
                        new ClientService(ordersBdContext), new ManagerService(ordersBdContext)))))
                {
                    fileWatcher.StartWatching();
                    Thread.Sleep(5000);
                    fileWatcher.StopWatching();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}