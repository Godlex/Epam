namespace Gift
{
    public class FruitMermelade : Marmalade
    {
        public FruitType FruitType { get; set; }
        public FruitMermelade(string name, double weight,double sugar,double price,MarmeladeTaste marmeladeTaste,FruitType fruitType) : base(name,weight,sugar,price,marmeladeTaste)
        {
            Name = name;
            Weight = weight;
            Sugar = sugar;
            Price = price;
            MarmeladeTaste = marmeladeTaste;
            FruitType = fruitType;
        }
        public override string ToString()
        {
            return $"Name: {Name}\n Weight: {Weight}\nCaloric: {Sugar}\nPrice: {Price}\nTaste: {MarmeladeTaste}\nFruitType: {FruitType}";
        }
    }
}