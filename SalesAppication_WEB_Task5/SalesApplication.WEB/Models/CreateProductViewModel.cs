namespace SalesApplication.WEB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateProductViewModel
    {
        [Required]
        public string Name { get; set; } 
    }
}