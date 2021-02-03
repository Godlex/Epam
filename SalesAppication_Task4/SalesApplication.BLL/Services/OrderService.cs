namespace SalesApplication.BLL
{
    using DAL;

    public class OrderService
    {
        private readonly OrdersBDContext _context;
        private readonly IProductService _productService;

        public OrderService(OrdersBDContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        public void MakeOrder(OrderModel orderModel)
        {
            var product = _productService.GetByName(orderModel?.ProductModel?.Name);
            if (product == null)
            {
               var productID = _productService.Add(new ProductModel(orderModel.ProductModel));
               orderModel.ProductModel.ProductId = productId;
               // Client Manager
            }
            _context.Orders.Add(orderModel); 
        }
    }
}