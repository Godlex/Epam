namespace SalesApplication.BLL.Services
{
    using System.Linq;
    using DAL;
    using DAL.Entities;

    public class ClientService : IClientService
    {
        private readonly OrdersBDContext _context;

        public ClientService(OrdersBDContext context)
        {
            _context = context;
        }

        public ClientModel GetByName(string name)
        {
            var client = _context.Clients.FirstOrDefault(client =>client.Name == name);
            return client == null ? null : MapClientToClientModel(client);
        }

        public int Add(ClientModel clientModel)
        {
            var client = MapClientModelToClient(clientModel);
            _context.Clients.Add(client);
            return client.ClientId;
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