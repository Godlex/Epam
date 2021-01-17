namespace AutomaticTelephoneExchange.Libary.BillingSystem
{
    using System.Collections.Generic;
    using EventArgs;

    public interface IBillingSystem
    {
        public void BillTheCallEventHandler(object? sender, BillTheCallEventArgs e);
        public IEnumerable<ExendetCallInfo> GetCallInfoByDate(string number);
        public IEnumerable<ExendetCallInfo> GetCallInfoByCost(string number);
        public IEnumerable<ExendetCallInfo> GetCallInfoByOutNumber(string number);
    }
}