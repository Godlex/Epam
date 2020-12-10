namespace Gift.lib.Models
{
    public class Brittle : Candy //грильяж 
    {
        public NutType NutType { get; set; }

        public Brittle(string name, double weight, double sugarWeight, double price, FilingType filingType, NutType nutType) :
            base(name, weight, sugarWeight, price, filingType)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            FilingType = filingType;
            NutType = nutType;
        }

        public override string ToString()
        {
            return
                $"Name: {Name}\n Weight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nFilling {FilingType}\nNutType: {NutType}\n";
        }
    }
}