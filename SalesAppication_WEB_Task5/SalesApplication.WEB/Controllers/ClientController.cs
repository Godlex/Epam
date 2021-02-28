namespace SalesApplication.WEB.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BLL.Models;
    using BLL.Services;
    using Constants;
    using Models;

    public class ClientController : Controller
    {
        private readonly IClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService(WebConstants.ConnectionString);
        }
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            List<ClientViewModel> clientViewModels = new List<ClientViewModel>();
            foreach (var orderModel in _clientService.GetClients())
            {
                clientViewModels.Add(MapClientModelToClientViewModel(orderModel));
            }

            return View(clientViewModels);
        }

        [HttpGet]
        [Authorize(Roles = WebConstants.AdminRole)]
        public ActionResult NewClient()
        {
            CreateClientViewModel createClientViewModel = new CreateClientViewModel();
            return View(createClientViewModel);
        }

        [Authorize(Roles = WebConstants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewClient(CreateClientViewModel client)
        {
            try
            {
                var a = _clientService.Add(new ClientModel
                {
                    Name = client.Name,
                });
                return RedirectToAction("Index", "Client");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        private ClientViewModel MapClientModelToClientViewModel(ClientModel orderModel)
        {
            return new ClientViewModel
            {
                Name = orderModel.Name
            };
        }
    }
}