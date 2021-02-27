namespace SalesApplication.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using DAL;
    using DAL.Entities;
    using Models;

    public class ClientService : IClientService
    {
        private readonly OrdersDbContext _context;

        public ClientService(string connectionString)
        {
            _context = new OrdersDbContext(connectionString);
        }

        public ClientModel GetByName(string name)
        {
            var client = _context.Clients.FirstOrDefault(c =>c.Name == name);
            return client == null ? null : MapClientToClientModel(client);
        }

        public int Add(ClientModel clientModel)
        {
            var client = MapClientModelToClient(clientModel);
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client.ClientId;
        }

        public IEnumerable<ClientModel> GetClients()
        {
            IList<ClientModel> clientModels = new List<ClientModel>();
            foreach (var client in _context.Clients)
            {
                clientModels.Add(MapClientToClientModel(client));
            }
            return clientModels;
        }

        private Client MapClientModelToClient(ClientModel clientModel)
        {
            return new Client {Name = clientModel.Name, ClientId = clientModel.ClientId};
        }
        
        private ClientModel MapClientToClientModel(Client client)
        {
            return new ClientModel {Name = client.Name, ClientId =client.ClientId};
        }
    }
}