﻿namespace SalesApplication.BLL
{
    using System.Linq;
    using DAL;

    public class ProductService : IProductService
    {
        //dbcontext
        private readonly OrdersBDContext _context;

        public ProductService(OrdersBDContext context)
        {
            _context = context;
        }

        public ProductModel GetByName(string name)
        {
            var product = _context.Products.FirstOrDefault(product => product.Name == name);
            return product == null ? null : MapProductToProductModel(product);
        }

        public int Add(ProductModel productModel)
        {
            var product = MapProductModelToProduct(productModel);
            _context.Products.Add(product);
            _context.SaveChanges();
            return product.ProductId;
        }

        private Product MapProductModelToProduct(ProductModel productModel)
        {
            return new Product {Name = productModel.Name, ProductId = productModel.ProductId};
        }
        
        private ProductModel MapProductToProductModel(Product product)
        {
            return new ProductModel {Name = product.Name, ProductId = product.ProductId};
        }
    }
}