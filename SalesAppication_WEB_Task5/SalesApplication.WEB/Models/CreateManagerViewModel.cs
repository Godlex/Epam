namespace SalesApplication.WEB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateManagerViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}