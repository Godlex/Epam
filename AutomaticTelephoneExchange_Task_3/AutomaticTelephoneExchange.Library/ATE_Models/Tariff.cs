namespace AutomaticTelephoneExchange.Library.ATE_Models
{
    public class Tariff
    {
        private double _pricePerMinute;
        private double _subscriptionFee;

        public Tariff(double pricePerMinute,double subscriptionFee)
        {
            _pricePerMinute = pricePerMinute;
            _subscriptionFee = subscriptionFee;
        }
    }
}