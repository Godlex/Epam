using System;

namespace Gift
{
    public abstract class Sweetness
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double SugarWeight { get; set; }
        public double Price { get; set; }

        public Sweetness(string name, double weight, double sugarWeight, double price)
        {
            Name = name;
            Weight = weight;
            SugarWeight = sugarWeight;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nWeight: {Weight}\n Caloric: {SugarWeight}\nPrice: {Price}\n";
        }
    }
}