namespace SalesApplication.BLL.Services
{
    using System.Linq;
    using DAL;
    using DAL.Entities;
    using Models;

    public class UserService : IUserService
    {
        private readonly OrdersDbContext _context;
        
        public UserService(string connectionString)
        {
            _context = new OrdersDbContext(connectionString);
        }

        public UserModel GetByEMail(string email)
        {
            var user = _context.Users.Include("Role").FirstOrDefault(u => u.Email == email);
            return MapUserToUserModel(user);
        }
        
        public UserModel GetByEMailAndPassword(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            return MapUserToUserModel(user);
        }
        public void Add(UserModel userModel)
        {
            _context.Users.Add(new User{Email = userModel.Email,Password = userModel.Password,RoleId = 1});
            _context.SaveChanges();
        }

        private UserModel MapUserToUserModel(User user)
        {
            if (user == null) return null;
            return new UserModel {Email = user.Email, Password = user.Password,RoleId = user.RoleId,Role = new RoleModel{Name = user.Role.Name}};
        }
    }
}