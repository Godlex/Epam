namespace SalesApplication.BLL.Models
{
    using System;
    using CsvHelper.Configuration.Attributes;

    public class SalesInfo
    {
        [Name("Date")]
        public DateTime Date{ get; set; }

        [Name("Client")]
        public ClientModel Client { get; set; }
        
        [Name("Product")]
        public ProductModel Product { get; set; }
        
        [Name("Cost")]
        public double Cost { get; set; }
    }
}