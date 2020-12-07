namespace Gift
{
    public class Brittle : Candy //грильяж 
    {
        public NutType NutType { get; set; }
        
        public Brittle(string name, double weight,double sugar,double price,Filing filing,NutType nutType) : base(name,weight,sugar,price,filing)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            Price = price;
            Filing = filing;
            NutType = nutType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Sugar}\nPrice: {Price}\nFilling {Filing}\nNutType: {NutType}\n";
        }
    }
}