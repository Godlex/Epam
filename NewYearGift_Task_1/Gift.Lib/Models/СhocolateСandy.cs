namespace Gift
{
    public class ChocolateCandy : Candy
    {
        public ChocolateType ChocolateType { get; set; }
        
        public ChocolateCandy(string name, double weight,double sugar,double price,Filing filing,ChocolateType chocolateType) : base(name,weight,sugar,price,filing)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            Price = price;
            Filing = filing;
            ChocolateType = chocolateType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Sugar}\nPrice: {Price}\nFiling: {Filing}\nChocolateType: {ChocolateType}\n";
        }
    }
}