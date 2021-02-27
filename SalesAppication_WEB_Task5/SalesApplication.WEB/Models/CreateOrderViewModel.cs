namespace SalesApplication.WEB.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateOrderViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid cost")]
        public double Cost { get; set; }
        public int ProductId { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }
    }
}