namespace SalesApplication.BLL.Models
{
    using System;

    public class SalesInfo
    {
        public DateTime Date{ get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public double Cost { get; set; }
    }
}