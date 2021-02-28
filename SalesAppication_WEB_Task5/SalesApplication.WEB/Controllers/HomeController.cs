namespace SalesApplication.WEB.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using BLL.Models;
    using BLL.Services;
    using Constants;
    using Models;

    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IManagerService _managerService;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public HomeController()
        {
            _orderService = new OrderService(WebConstants.ConnectionString);
            _managerService = new ManagerService(WebConstants.ConnectionString);
            _clientService = new ClientService(WebConstants.ConnectionString);
            _productService = new ProductService(WebConstants.ConnectionString);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index(int? manager, int? client, int? product)
        {
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var orderModel in _orderService.GetOrders(manager, client, product))
            {
                orderViewModels.Add(MapOrderModelToOrderViewModel(orderModel));
            }

            var managerModels = _managerService.GetManagers().ToList();
            managerModels.Insert(0, new ManagerModel {ManagerId = 0, SecondName = "All"});

            var clientModels = _clientService.GetClients().ToList();
            clientModels.Insert(0, new ClientModel {ClientId = 0, Name = "All"});

            var productModels = _productService.GetProducts().ToList();
            productModels.Insert(0, new ProductModel {ProductId = 0, Name = "All"});

            ViewBag.Managers = new SelectList(managerModels, nameof(ManagerModel.ManagerId),
                nameof(ManagerModel.SecondName));
            ViewBag.Clients = new SelectList(clientModels, nameof(ClientModel.ClientId), nameof(ClientModel.Name));
            ViewBag.Products = new SelectList(productModels, nameof(ProductModel.ProductId), nameof(ProductModel.Name));

            return View(orderViewModels);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetOrderTable(int? manager, int? client, int? product)
        {
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var orderModel in _orderService.GetOrders(manager, client, product))
            {
                orderViewModels.Add(MapOrderModelToOrderViewModel(orderModel));
            }

            var managerModels = _managerService.GetManagers().ToList();
            managerModels.Insert(0, new ManagerModel {ManagerId = 0, SecondName = "All"});

            var clientModels = _clientService.GetClients().ToList();
            clientModels.Insert(0, new ClientModel {ClientId = 0, Name = "All"});

            var productModels = _productService.GetProducts().ToList();
            productModels.Insert(0, new ProductModel {ProductId = 0, Name = "All"});

            ViewBag.Managers = new SelectList(managerModels, nameof(ManagerModel.ManagerId),
                nameof(ManagerModel.SecondName));
            ViewBag.Clients = new SelectList(clientModels, nameof(ClientModel.ClientId), nameof(ClientModel.Name));
            ViewBag.Products = new SelectList(productModels, nameof(ProductModel.ProductId), nameof(ProductModel.Name));

            return PartialView(orderViewModels);
        }

        [HttpGet]
        [Authorize(Roles = WebConstants.AdminRole)]
        public ActionResult MakeOrder()
        {
            ViewBag.Managers = new SelectList(_managerService.GetManagers(), "ManagerId", "SecondName");
            ViewBag.Clients = new SelectList(_clientService.GetClients(), "ClientId", "Name");
            ViewBag.Products = new SelectList(_productService.GetProducts(), "ProductId", "Name");
            CreateOrderViewModel createOrderViewModel = new CreateOrderViewModel();
            return View(createOrderViewModel);
        }

        [Authorize(Roles = WebConstants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakeOrder(CreateOrderViewModel order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            try
            {
                _orderService.MakeOrder(new OrderModel
                {
                    ClientId = order.ClientId, ManagerId = order.ManagerId, ProductId = order.ProductId,
                    Cost = order.Cost, Date = DateTime.Now
                });
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(order);
        }

        private OrderViewModel MapOrderModelToOrderViewModel(OrderModel orderModel)
        {
            return new OrderViewModel
            {
                Cost = orderModel.Cost,
                Date = orderModel.Date,
                OrderId = orderModel.OrderId,
                Client = orderModel.ClientModel.Name,
                Product = orderModel.ProductModel.Name,
                Manager = orderModel.ManagerModel.SecondName
            };
        }
    }
}