namespace SalesApplication.BLL.Models
{
    using CsvHelper.Configuration;

    public class SalesInfoMap : ClassMap<SalesInfo>
    {
        public SalesInfoMap()
        {
            Map(m => m.Date).Name("Date");
            Map(m => m.Client).Name("Client");
            Map(m => m.Product).Name("Product");
            Map(m => m.Cost).Name("Cost");
        }
    }
}