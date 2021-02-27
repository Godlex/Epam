namespace SalesApplication.BLL.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IManagerService
    {
        ManagerModel GetByName(string name);

        int Add(ManagerModel managerModel);
        IEnumerable<ManagerModel> GetManagers();
    }
}