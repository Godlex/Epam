namespace Gift
{
    public class Marmalade : Sweetness
    {
        public MarmeladeTaste MarmeladeTaste { get; set; }

        public Marmalade(string name, double weight, double sugarWeight, double price, MarmeladeTaste marmeladeTaste) :
            base(name, weight, sugarWeight, price)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            MarmeladeTaste = marmeladeTaste;
        }

        public override string ToString()
        {
            return
                $"Name: {Name}\nWeight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nTaste: {MarmeladeTaste}\n";
        }
    }
}