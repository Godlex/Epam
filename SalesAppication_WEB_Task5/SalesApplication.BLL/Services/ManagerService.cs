namespace SalesApplication.BLL.Services
{
    using System.Linq;
    using DAL;

    public class ManagerService : IManagerService
    {
        private readonly OrdersBDContext _context;

        public ManagerService(OrdersBDContext context)
        {
            _context = context;
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