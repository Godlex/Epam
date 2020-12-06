namespace Gift
{
    public class Gummy : Marmalade
    {
        public Color Color { get; set; }
        public Gummy(string name, double weight,double caloric,double price,MarmeladeTaste marmeladeTaste,Color color) : base(name,weight,caloric,price,marmeladeTaste)
        {
            Name = name;
            Weight = weight;
            Caloric = caloric;
            Price = price;
            MarmeladeTaste=marmeladeTaste;
            Color = color;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Caloric}\nPrice: {Price}\nTaste: {MarmeladeTaste}\nColor: {Color}";
        }
    }
}