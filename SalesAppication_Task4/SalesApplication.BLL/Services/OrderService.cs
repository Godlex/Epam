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

        public OrderService(OrdersBDContext context, IProductService productService, IClientService clientService, IManagerService managerService)
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
            orderModel.ManagerModel.ManagerId = managerId;

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
                Client = new Client {ClientId = orderModel.ClientId, Name = orderModel.ClientModel.Name},
                ClientId = orderModel.ClientId, Cost = orderModel.Cost, Date = orderModel.Date,
                Manager = new Manager
                    {ManagerId = orderModel.ManagerId, SecondName = orderModel.ManagerModel.SecondName},
                ManagerId = orderModel.ManagerId, OrderId = orderModel.OrderId,
                Product = new Product {Name = orderModel.ProductModel.Name, ProductId = orderModel.ProductId},
                ProductId = orderModel.ProductId
            };
        }
        }
    }