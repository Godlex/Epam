namespace SalesApplication.WEB.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using BLL.Models;
    using BLL.Services;
    using Constants;
    using Models;

    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService(WebConstants.ConnectionString);
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            foreach (var orderModel in _productService.GetProducts())
            {
                productViewModels.Add(MapProductModelToProductViewModel(orderModel));
            }

            return View(productViewModels);
        }

        [HttpGet]
        [Authorize(Roles = WebConstants.AdminRole)]
        public ActionResult NewProduct()
        {
            CreateProductViewModel createProductViewModel = new CreateProductViewModel();
            return View(createProductViewModel);
        }

        [HttpPost]
        [Authorize(Roles = WebConstants.AdminRole)]
        [ValidateAntiForgeryToken]
        public ActionResult NewProduct(CreateProductViewModel product)
        {
            try
            {
                var a = _productService.Add(new ProductModel
                {
                    Name = product.Name
                });
                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        private ProductViewModel MapProductModelToProductViewModel(ProductModel productModel)
        {
            return new ProductViewModel
            {
                Name = productModel.Name
            };
        }
    }
}