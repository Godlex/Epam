namespace SalesApplication.BLL.Services
{
    public interface IManagerService
    {
        ManagerModel GetByName(string name);

        int Add(ManagerModel managerModel);
    }
}