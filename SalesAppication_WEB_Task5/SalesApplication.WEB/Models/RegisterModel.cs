namespace SalesApplication.WEB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Password mismatch")]
        public string ConfirmPassword { get; set; }

    }
}