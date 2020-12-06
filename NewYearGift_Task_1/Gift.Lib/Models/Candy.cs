namespace Gift
{
    public class Candy : Sweetness
    {
        public Filing Filing { get; set; }
        public Candy(string name, double weight,double caloric,double price,Filing filing) : base(name,weight,caloric,price)
        {
            Name = name;
            Weight = weight;
            Caloric = caloric;
            Price = price;
            Filing = filing;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Caloric}\nPrice: {Price}\nFilling: {Filing}\n";
        }
    }
}