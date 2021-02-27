namespace SalesApplication.WEB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateClientViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}