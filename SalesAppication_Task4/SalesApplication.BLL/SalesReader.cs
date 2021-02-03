namespace SalesApplication.BLL
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using CsvHelper;
    using DAL;
    using Models;

    public class SalesReader : ISalesReader
    {
        private readonly OrdersBDContext _context;
        
        public static IEnumerable<SalesInfo> Read(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<SalesInfoMap>();
                return csv.GetRecord<SalesInfo>();
            }
        }
    }
}