namespace Gift
{
    public class ChocolateCandy : Candy
    {
        public ChocolateType ChocolateType { get; set; }
        
        public ChocolateCandy(string name, double weight,double sugarWeight,double price,Filing filing,ChocolateType chocolateType) : base(name,weight,sugarWeight,price,filing)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            Filing = filing;
            ChocolateType = chocolateType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nFiling: {Filing}\nChocolateType: {ChocolateType}\n";
        }
    }
}