namespace SalesApplication.BLL.Models
{
    using System;

    public class OrderModel
    {
        public int OrderId { get; set; } 
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }
        
        public int ClientId { get; set; }
        public ClientModel ClientModel { get; set; }
        
        public int ManagerId { get; set; }
        public ManagerModel ManagerModel { get; set; }
    }
}