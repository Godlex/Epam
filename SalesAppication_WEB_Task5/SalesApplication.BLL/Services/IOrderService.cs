namespace SalesApplication.BLL.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IOrderService
    {
        void MakeOrder(OrderModel orderModel);
        IEnumerable<OrderModel> GetOrders(int? manager, int? client, int? product);
    }
}