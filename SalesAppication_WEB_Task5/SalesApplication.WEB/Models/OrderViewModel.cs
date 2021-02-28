namespace SalesApplication.WEB.Models
{
    using System;

    public class OrderViewModel
    {
        public int OrderId { get; set; } 
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public string Product { get; set; }
        public string Client { get; set; }
        public string Manager { get; set; }
    }
}