namespace SalesApplication.BLL.Services
{
    using DAL.Entities;
    using Models;

    public interface IUserService
    {
        UserModel GetByEMail(string email);
        UserModel GetByEMailAndPassword(string email, string password);
        
        void Add(UserModel userModel);
    }
}