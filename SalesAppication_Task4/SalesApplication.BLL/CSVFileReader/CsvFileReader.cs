namespace SalesApplication.BLL.CSVFileReader
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using Models;

    public class CsvFileReader : ICsvFileReader
    {
        public IEnumerable<SalesInfo> Read(string filePath)
        {
            Console.WriteLine("Govno rabotaet");
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<SalesInfoMap>();
                var a = csv.GetRecords<SalesInfo>();
                return a.ToList();
            }
        }
    }
}