namespace SalesApplication.WEB.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BLL.Models;
    using BLL.Services;
    using Models;

    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService("SalesDB");
        }
        public ActionResult Index()
        {
            List<ClientViewModel> clientViewModels = new List<ClientViewModel>();
            foreach (var orderModel in _clientService.GetClients())
            {
                clientViewModels.Add(MapClientModelToClientViewModel(orderModel));
            }
            return View(clientViewModels);
        }

        private ClientViewModel MapClientModelToClientViewModel(ClientModel orderModel)
        {
            return new ClientViewModel
            {
                Name = orderModel.Name
            };
        }

        public ActionResult NewClient()
        {
            CreateClientViewModel createClientViewModel = new CreateClientViewModel();
            return View(createClientViewModel);
        }

        [HttpPost]
        public ActionResult NewClient(CreateClientViewModel client)
        {
            try
            {
                var a = _clientService.Add(new ClientModel
                {
                    Name = client.Name,
                });
                return Redirect("/Client/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
            }
            return View();
        }
    }
}