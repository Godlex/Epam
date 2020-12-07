namespace Gift
{
    public class Gummy : Marmalade
    {
        public Color Color { get; set; }
        public Gummy(string name, double weight,double sugar,double price,MarmeladeTaste marmeladeTaste,Color color) : base(name,weight,sugar,price,marmeladeTaste)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            Price = price;
            MarmeladeTaste=marmeladeTaste;
            Color = color;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Sugar}\nPrice: {Price}\nTaste: {MarmeladeTaste}\nColor: {Color}";
        }
    }
}