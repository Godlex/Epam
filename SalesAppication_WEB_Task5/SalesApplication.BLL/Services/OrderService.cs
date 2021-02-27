namespace SalesApplication.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using DAL;
    using DAL.Entities;
    using Models;

    public class OrderService : IOrderService
    {
        private readonly OrdersDbContext _context;

        public OrderService(string connectionString) 
        {
            _context = new OrdersDbContext(connectionString);
        }

        public void MakeOrder(OrderModel orderModel)
        {
            var order = MapOrderModelToOrder(orderModel);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<OrderModel> GetOrders(int? manager, int? client, int? product)
        {
            IQueryable<Order> orders = _context.Orders.Include("Client").Include("Manager").Include("Product");
            if (manager != null && manager != 0)
            {
                orders = orders.Where(x => x.ManagerId == manager.Value);
            }

            if (client != null && client != 0)
            {
                orders = orders.Where(x => x.ClientId == client.Value);
            }

            if (product != null && product != 0)
            {
                orders = orders.Where(x => x.ProductId == product.Value);
            }

            IList<OrderModel> orderModels = new List<OrderModel>();
            foreach (var order in orders)
            {
                orderModels.Add(MapOrderToOrderModel(order));
            }

            return orderModels;
        }

        private OrderModel MapOrderToOrderModel(Order order)
        {
            return new OrderModel
            {
                ClientId = order.ClientId,
                Cost = order.Cost,
                Date = order.Date,
                ManagerId = order.ManagerId,
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                ClientModel = new ClientModel {Name = order.Client.Name},
                ProductModel = new ProductModel {Name = order.Product.Name},
                ManagerModel = new ManagerModel {SecondName = order.Manager.SecondName}
            };
        }

        private Order MapOrderModelToOrder(OrderModel orderModel)
        {
            return new Order
            {
                ClientId = orderModel.ClientId,
                Cost = orderModel.Cost,
                Date = orderModel.Date,
                ManagerId = orderModel.ManagerId,
                OrderId = orderModel.OrderId,
                ProductId = orderModel.ProductId
            };
        }
    }
}