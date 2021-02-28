namespace SalesApplication.WEB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateClientViewModel
    {
        [Required(ErrorMessage = "Please enter a valid Name")]
        public string Name { get; set; }
    }
}