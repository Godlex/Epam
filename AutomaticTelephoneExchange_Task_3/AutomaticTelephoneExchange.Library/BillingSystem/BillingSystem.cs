namespace AutomaticTelephoneExchange.Libary.BillingSystem
{
    using System.Collections.Generic;
    using System.Linq;
    using ATE_Models;
    using EventArgs;

    public class BillingSystem : IBillingSystem
    {
        public IList<Contract> Contracts = new List<Contract>();
        private readonly IList<ExendetCallInfo> _extendedCallInfos = new List<ExendetCallInfo>();

        public void BillTheCallEventHandler(object? sender, BillTheCallEventArgs e)
        {
            _extendedCallInfos.Add(new ExendetCallInfo(e.CallInfo, GetContractByPhoneNumber(e.CallInfo.InPhoneNumber).Tariff.PricePerMinute));
        }
        
        public IEnumerable<ExendetCallInfo> GetCallInfoByDate(string number)
        { var a = _extendedCallInfos.OrderBy(info => info.StartCall).Where(info => info.InPhoneNumber == number || info.OutPhoneNumber==number);
            return a;
        }
        public IEnumerable<ExendetCallInfo> GetCallInfoByCost(string number)
        { var a = _extendedCallInfos.OrderBy(info => info.Cost).Where(info => info.InPhoneNumber == number || info.OutPhoneNumber==number);
            return a;
        }
        public IEnumerable<ExendetCallInfo> GetCallInfoByOutNumber(string number)
        { var a = _extendedCallInfos.OrderBy(info => info.OutPhoneNumber).Where(info => info.InPhoneNumber == number || info.OutPhoneNumber==number);
            return a;
        }
        private Contract GetContractByPhoneNumber(string number)
        {
            return Contracts.FirstOrDefault(contract => contract.PhoneNumber == number);
        }
        
        private Client GetClientByPhoneNumber(string number)
        {
            return Contracts.FirstOrDefault(contract => contract.PhoneNumber == number).Client;
        }
    }
}