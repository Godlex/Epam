namespace SalesApplication.BLL
{
    using DAL;
    using DAL.Entities;
    using Services;

    public class OrderService : IOrderService
    {
        private readonly OrdersBDContext _context;
        private readonly IProductService _productService;
        private readonly IClientService _clientService;
        private readonly IManagerService _managerService;

        public OrderService(OrdersBDContext context, IProductService productService, IClientService clientService,
            IManagerService managerService)
        {
            _context = context;
            _productService = productService;
            _clientService = clientService;
            _managerService = managerService;
        }

        public void MakeOrder(OrderModel orderModel)
        {
            var productId = CreateProductIfNotExist(orderModel);
            orderModel.ProductId = productId;

            var clientId = CreateClientIfNotExist(orderModel);
            orderModel.ClientId = clientId;

            var managerId = CreateManagerIfNotExist(orderModel);
            orderModel.ManagerId = managerId;

            var order = MapOrderModelToOrder(orderModel);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        private int CreateManagerIfNotExist(OrderModel orderModel) //Manager
        {
            var manager = _managerService.GetByName(orderModel?.ManagerModel?.SecondName);
            if (manager != null) return manager.ManagerId;

            var managerId = _managerService.Add(new ManagerModel {SecondName = orderModel?.ManagerModel?.SecondName});

            return managerId;
        }

        private int CreateClientIfNotExist(OrderModel orderModel) //Client
        {
            var client = _clientService.GetByName(orderModel?.ClientModel?.Name);
            if (client != null) return client.ClientId;

            var clientId = _clientService.Add(new ClientModel {Name = orderModel?.ClientModel?.Name});

            return clientId;
        }


        private int CreateProductIfNotExist(OrderModel orderModel)
        {
            var product = _productService.GetByName(orderModel?.ProductModel?.Name);
            if (product != null) return product.ProductId;

            var productId = _productService.Add(new ProductModel {Name = orderModel?.ProductModel?.Name});

            return productId;
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
        //Enumerable<OrderModel> GetOrders()
        
    }
}