namespace SalesApplication.DAL
{
    using System;
    using Entities;

    public class Order
    {
        public int OrderId { get; set; } 
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
        
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}