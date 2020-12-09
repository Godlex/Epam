namespace Gift
{
    public class Candy : Sweetness
    {
        public Filing Filing { get; set; } //Type
        public Candy(string name, double weight,double sugarWeight,double price,Filing filing) : base(name,weight,sugarWeight,price)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            Filing = filing;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nFilling: {Filing}\n";
        }
    }
}