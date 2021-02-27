namespace SalesApplication.BLL.Services
{
    using System.Collections.Generic;
    using Models;

    public interface IProductService
    {
        ProductModel GetByName(string name);

        int Add(ProductModel productModel);
        IEnumerable<ProductModel> GetProducts();
    }
}