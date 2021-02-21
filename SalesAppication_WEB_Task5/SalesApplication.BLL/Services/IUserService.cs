namespace SalesApplication.BLL.Services
{
    using DAL.Entities;

    public interface IUserService
    {
        User GetByEMail(string email);
        User GetByEMailAndPassword(string email, string password);
        
        void Add(string email, string password);
    }
}