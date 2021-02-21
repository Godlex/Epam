namespace SalesApplication.BLL.Services
{
    using System.Linq;
    using DAL;
    using DAL.Entities;

    public class UserService : IUserService
    {
        private readonly OrdersDbContext _context;

        public UserService(OrdersDbContext context)
        {
            _context = context;
        }

        public User GetByEMail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email == email);
        }
        
        public User GetByEMailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(user => user.Email == email && user.Password == password);
        }
        public void Add(string email, string password)
        {
            _context.Users.Add(new User{Email = email,Password = password});
            _context.SaveChanges();
        }
    }
}