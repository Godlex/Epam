namespace SalesApplication.BLL.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IClientService
    {
        ClientModel GetByName(string name);

        int Add(ClientModel clientModel);
        IEnumerable<ClientModel> GetClients();
    }
}