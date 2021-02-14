namespace SalesApplication.BLL.CSVFileReader
{
    using System.Collections.Generic;
    using CsvHelper.Configuration;

    public interface ICsvFileReader<TMap,TModel>
    where TModel : class, new() 
    where TMap : ClassMap<TModel>
    {
        IEnumerable<TModel> Read(string filePath);
    }
}