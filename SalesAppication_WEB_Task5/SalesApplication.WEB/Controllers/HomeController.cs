namespace SalesApplication.WEB.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BLL.Models;
    using BLL.Services;
    using Models;

    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            //getOrders // OrderModel Map to OrderViewModel
            OrderService orderService = new OrderService("SalesDB");
            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();
            foreach (var orderModel in orderService.GetOrders())
            {
                orderViewModels.Add(MapOrderModelToOrderViewModel(orderModel));
            }
            return View(orderViewModels);
        }

        public HomeController()
        {
            //createNewInstanceOfOrderService
        }

        public ActionResult MakeOrder(int id)
        {
            return null;
        }

        private OrderViewModel MapOrderModelToOrderViewModel(OrderModel orderModel)
        {
            return new OrderViewModel
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