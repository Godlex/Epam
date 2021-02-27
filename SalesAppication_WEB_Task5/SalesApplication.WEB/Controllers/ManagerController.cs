namespace SalesApplication.WEB.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BLL.Models;
    using BLL.Services;
    using Models;

    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;

        public ManagerController()
        {
            _managerService = new ManagerService("SalesDB");
        }
        public ActionResult Index()
        {
            List<ManagerViewModel> managerViewModels = new List<ManagerViewModel>();
            foreach (var orderModel in _managerService.GetManagers())
            {
                managerViewModels.Add(MapManagerModelToManagerViewModel(orderModel));
            }
            return View(managerViewModels);
        }

        private ManagerViewModel MapManagerModelToManagerViewModel(ManagerModel managerModel)
        {
            return new ManagerViewModel
            {
                Manager = managerModel.SecondName
            };
        }

        public ActionResult NewManager()
        {
            CreateManagerViewModel createManagerViewModel = new CreateManagerViewModel(); 
            return View(createManagerViewModel);
        }
        [HttpPost]
        public ActionResult NewManager(CreateManagerViewModel manager)
        {
            if(!ModelState.IsValid)return View(manager);
            try
            {
                var managerId = _managerService.Add(new ManagerModel
                {
                    SecondName = manager.Name,
                });
                return Redirect("/Manager/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
            }
            return View(manager);
        }
    }
}