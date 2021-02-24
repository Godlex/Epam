namespace SalesApplication.BLL.Services
{
    using Models;

    public interface IManagerService
    {
        ManagerModel GetByName(string name);

        int Add(ManagerModel managerModel);
    }
}