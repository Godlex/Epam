namespace SalesApplication.BLL.CSVFileReader
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using CsvHelper.Configuration;

    public class CsvFileReader<TMap,TModel> : ICsvFileReader<TMap,TModel>
        where TModel : class, new() 
        where TMap : ClassMap<TModel>
    {
        public IEnumerable<TModel> Read(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<TMap>();
                var models = csv.GetRecords<TModel>();
                return models.ToList();
            }
        }
    }
}