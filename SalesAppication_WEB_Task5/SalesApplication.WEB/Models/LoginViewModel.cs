namespace SalesApplication.WEB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}