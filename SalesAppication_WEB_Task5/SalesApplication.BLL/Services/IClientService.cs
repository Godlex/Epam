namespace SalesApplication.BLL.Services
{
    public interface IClientService
    {
        ClientModel GetByName(string name);

        int Add(ClientModel clientModel);
    }
}