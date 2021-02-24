namespace SalesApplication.BLL.Services
{
    using Models;

    public interface IOrderService
    {
        void MakeOrder(OrderModel orderModel);
    }
}