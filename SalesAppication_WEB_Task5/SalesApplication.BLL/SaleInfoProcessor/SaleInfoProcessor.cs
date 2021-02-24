namespace SalesApplication.BLL.SaleInfoProcessor
{
    using System.Collections.Generic;
    using Models;
    using Services;

    public class SaleInfoProcessor : ISaleInfoProcessor
    {
        private readonly IOrderService _orderService;

        public SaleInfoProcessor(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public void Processes(IEnumerable<SalesInfo> salesInfos,string managerSecondName)
        {
            foreach (var sale in salesInfos)
            {
                _orderService.MakeOrder(new OrderModel
                {
                    ClientModel = new ClientModel {Name = sale.Client}, Cost = sale.Cost, Date = sale.Date,
                    ProductModel = new ProductModel {Name = sale.Product},ManagerModel = new ManagerModel{SecondName = managerSecondName }
                });
            }
        }
    }
}