namespace SalesApplication.BLL.Services
{
    using Models;

    public interface IProductService
    {
        ProductModel GetByName(string name);

        int Add(ProductModel productModel);
    }
}