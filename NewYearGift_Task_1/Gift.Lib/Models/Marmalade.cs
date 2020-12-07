
namespace Gift
{
    public class Marmalade : Sweetness
    {
        public MarmeladeTaste MarmeladeTaste { get; set; }
        public Marmalade(string name, double weight,double sugar,double price,MarmeladeTaste marmeladeTaste) : base(name,weight,sugar,price)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            Price = price;
            MarmeladeTaste=marmeladeTaste;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Sugar}\nPrice: {Price}\nTaste: {MarmeladeTaste}\n";
        }
    }
}