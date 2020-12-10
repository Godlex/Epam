namespace Gift
{
    public class ChocolateCandy : Candy
    {
        public ChocolateType ChocolateType { get; set; }

        public ChocolateCandy(string name, double weight, double sugarWeight, double price, FilingType filingType,
            ChocolateType chocolateType) : base(name, weight, sugarWeight, price, filingType)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            FilingType = filingType;
            ChocolateType = chocolateType;
        }

        public override string ToString()
        {
            return
                $"Name: {Name}\nWeight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nFiling: {FilingType}\nChocolateType: {ChocolateType}\n";
        }
    }
}