namespace SalesApplication.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using DAL;
    using DAL.Entities;
    using Models;

    public class ManagerService : IManagerService
    {
        private readonly OrdersDbContext _context;

        public ManagerService(string connectionString)
        {
            _context = new OrdersDbContext(connectionString);
        }

        public ManagerModel GetByName(string name)
        {
            var manager = _context.Managers.FirstOrDefault(client =>client.SecondName == name);
            return manager == null ? null : MapManagerToManagerModel(manager);
        }

        public int Add(ManagerModel managerModel)
        {
            var manager = MapManagerModelToManager(managerModel);
            _context.Managers.Add(manager);
            _context.SaveChanges();
            return manager.ManagerId;
        }
        public IEnumerable<ManagerModel> GetManagers()
        {
            IList<ManagerModel> managerModels = new List<ManagerModel>();
            foreach (var manager in _context.Managers)
            {
                managerModels.Add(MapManagerToManagerModel(manager));
            }
            return managerModels;
        }

        private Manager MapManagerModelToManager(ManagerModel managerModel)
        {
            return new Manager {SecondName = managerModel.SecondName, ManagerId = managerModel.ManagerId};
        }
        
        private ManagerModel MapManagerToManagerModel(Manager manager)
        {
            return new ManagerModel {SecondName = manager.SecondName, ManagerId = manager.ManagerId};
        }
    }
}