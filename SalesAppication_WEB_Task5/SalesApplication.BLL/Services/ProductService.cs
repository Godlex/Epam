namespace SalesApplication.BLL.Services
{
    using System.Linq;
    using DAL;
    using DAL.Entities;
    using Models;

    public class ProductService : IProductService
    {
        //dbcontext
        private readonly OrdersDbContext _context;

        public ProductService(string connectionString)//connectionString
        {
            _context = new OrdersDbContext(connectionString);
        }

        public ProductModel GetByName(string name)
        {
            var product = _context.Products.FirstOrDefault(p => p.Name == name);
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