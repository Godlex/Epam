namespace SalesApplication.BLL
{
    using CsvHelper.Configuration;
    using Models;

    public class SalesInfoMap : ClassMap<SalesInfo>
    {
        public SalesInfoMap()
        {
            Map(m => m.Date).Name("date");
            Map(m => m.Client).Name("client");
            Map(m => m.Product).Name("product");
            Map(m => m.Cost).Name("cost");
        }
    }
}