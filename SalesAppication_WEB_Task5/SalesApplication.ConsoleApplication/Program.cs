namespace SalesApplication.ConsoleApplication
{
    using System;
    using System.Configuration;
    using System.Threading;
    using BLL;
    using BLL.CSVFileReader;
    using BLL.FileWatcher;
    using BLL.Models;
    using BLL.SaleInfoProcessor;
    using BLL.Services;
    using DAL;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = ConfigurationManager.AppSettings["SaleInfoDirPath"];
                OrdersDbContext ordersDbContext = new OrdersDbContext("SalesDB");
                using (FileWatcher fileWatcher = new FileWatcher(new CsvFileReader<SalesInfoMap, SalesInfo>(), path,
                    new SaleInfoProcessor(new OrderService("SalesDB"))))
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