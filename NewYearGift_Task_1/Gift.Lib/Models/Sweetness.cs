using System;

namespace Gift
{
    public abstract class Sweetness
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Sugar { get; set; }
        public double Price { get; set; }

        public Sweetness(string name, double weight, double sugar, double price)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\n Caloric: {Sugar}\nPrice: {Price}\n";
        }
    }
}