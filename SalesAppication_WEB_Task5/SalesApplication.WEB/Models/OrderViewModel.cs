namespace SalesApplication.WEB.Models
{
    using System;

    public class OrderViewModel
    {
        public int OrderId { get; set; } 
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        
        public int ProductId { get; set; }
        public ProductViewModel Product { get; set; }
        
        public int ClientId { get; set; }
        public ClientViewModel Client { get; set; }
        
        public int ManagerId { get; set; }
        public ManagerViewModel Manager { get; set; }
    }
}