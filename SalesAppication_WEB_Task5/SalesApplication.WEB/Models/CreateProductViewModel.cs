namespace SalesApplication.WEB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Please enter a valid Name")]
        public string Name { get; set; } 
    }
}