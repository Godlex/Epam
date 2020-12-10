namespace Gift
{
    public class Candy : Sweetness
    {
        public FilingType FilingType { get; set; } 

        public Candy(string name, double weight, double sugarWeight, double price, FilingType filingType) : base(name, weight,
            sugarWeight, price)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            FilingType = filingType;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nFilling: {FilingType}\n";
        }
    }
}