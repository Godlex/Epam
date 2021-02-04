namespace SalesApplication.BLL
{
    public interface IProductService
    {
        ProductModel GetByName(string name);

        int Add(ProductModel productModel);
    }
}