namespace Gift
{
    public abstract class Sweetness
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Caloric { get; set; }
        public double Price { get; set; }
        public Sweetness(string name, double weight,double caloric,double price)
        {
            Name = name;
            Weight = weight;
            Caloric = caloric;
            Price = price;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\n Caloric: {Caloric}\nPrice: {Price}\n";
        }
        
    }
}