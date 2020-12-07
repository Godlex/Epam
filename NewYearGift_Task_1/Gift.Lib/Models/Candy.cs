namespace Gift
{
    public class Candy : Sweetness
    {
        public Filing Filing { get; set; }
        public Candy(string name, double weight,double sugar,double price,Filing filing) : base(name,weight,sugar,price)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            Price = price;
            Filing = filing;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Sugar}\nPrice: {Price}\nFilling: {Filing}\n";
        }
    }
}