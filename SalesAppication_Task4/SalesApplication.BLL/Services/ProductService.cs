namespace SalesApplication.BLL
{
    using System.Linq;
    using DAL;

    public class ProductService
    {
        //dbcontext
        private readonly OrdersBDContext _context;

        public ProductModel GetById(int id)
        {
            return _context.Products.FirstOrDefault(product => product.ProductId == id);
        }

        public int Add(ProductModel productModel)
        {
            _context.Products.Add(productModel);
            return productModel.ProductId;
        }
    }
}