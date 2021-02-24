namespace SalesApplication.BLL.Services
{
    using Models;

    public interface IClientService
    {
        ClientModel GetByName(string name);

        int Add(ClientModel clientModel);
    }
}