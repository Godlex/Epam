namespace Gift
{
    public class ChocolateCandy : Candy
    {
        public ChocolateType ChocolateType { get; set; }
        
        public ChocolateCandy(string name, double weight,double caloric,double price,Filing filing,ChocolateType chocolateType) : base(name,weight,caloric,price,filing)
        {
            Name = name;
            Weight = weight;
            Caloric = caloric;
            Price = price;
            Filing = filing;
            ChocolateType = chocolateType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Caloric}\nPrice: {Price}\nFiling: {Filing}\nChocolateType: {ChocolateType}\n";
        }
    }
}