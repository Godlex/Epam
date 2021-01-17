namespace AutomaticTelephoneExchange.Libary.BillingSystem
{
    using ATE_Models;

    public class ExendetCallInfo : CallInfo
    {
        public double Cost { get; set; }
        public ExendetCallInfo(CallInfo callInfo,double pricePerMinute)
        {
            Guid =callInfo.Guid;
            Duration = callInfo.Duration;
            OutPhoneNumber = callInfo.OutPhoneNumber;
            InPhoneNumber = callInfo.InPhoneNumber;
            StartCall = callInfo.StartCall;
            Cost = GetCoast(pricePerMinute);
        }
        private double GetCoast(double pricePerMinute)
        {
            return Duration.Value.Seconds * pricePerMinute;
        }
    }
}