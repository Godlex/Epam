namespace SalesApplication.WEB.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string Password { get;set;}
        
        public int RoleId { get; set; }
        public RoleViewModel Role { get; set; }
    }
}