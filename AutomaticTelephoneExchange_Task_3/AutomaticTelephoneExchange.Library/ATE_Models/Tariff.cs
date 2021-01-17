namespace AutomaticTelephoneExchange.Libary.ATE_Models
{
    public class Tariff
    {
        private string _name;
        public readonly double PricePerMinute;
        public Tariff(double pricePerMinute, string name)
        {
            PricePerMinute = pricePerMinute;
            _name = name;
        }
    }
}