
namespace Gift
{
    public class Marmalade : Sweetness
    {
        public MarmeladeTaste MarmeladeTaste { get; set; }
        public Marmalade(string name, double weight,double caloric,double price,MarmeladeTaste marmeladeTaste) : base(name,weight,caloric,price)
        {
            Name = name;
            Weight = weight;
            Caloric = caloric;
            Price = price;
            MarmeladeTaste=marmeladeTaste;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Caloric}\nPrice: {Price}\nTaste: {MarmeladeTaste}\n";
        }
    }
}