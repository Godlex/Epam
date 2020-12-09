namespace Gift
{
    public class Gummy : Marmalade
    {
        public Color Color { get; set; }
        public Gummy(string name, double weight,double sugarWeight,double price,MarmeladeTaste marmeladeTaste,Color color) : base(name,weight,sugarWeight,price,marmeladeTaste)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
            MarmeladeTaste=marmeladeTaste;
            Color = color;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {SugarWeight}\nPrice: {Price}\nTaste: {MarmeladeTaste}\nColor: {Color}";
        }
    }
}